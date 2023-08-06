



using IdentityModel.OidcClient;

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Application.Queries;

public class FeedbackReportQueries : IFeedbackReportQueries
{
    private string _connectionString = string.Empty;


    public FeedbackReportQueries(string constr)
    {
        _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
    }

    public async Task<FeedbackReport> GetFeedbackReportAsync(Guid id)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        //TODO: Replace w/ correct query expression
        var result = await connection.QueryAsync<dynamic>(
            @"select o.[Id] as ordernumber,o.OrderDate as date, o.Description as description,
                    o.Address_City as city, o.Address_Country as country, o.Address_State as state, o.Address_Street as street, o.Address_ZipCode as zipcode,
                    os.Name as status, 
                    oi.ProductName as productname, oi.Units as units, oi.UnitPrice as unitprice, oi.PictureUrl as pictureurl
                    FROM ordering.Orders o
                    LEFT JOIN ordering.Orderitems oi ON o.Id = oi.orderid 
                    LEFT JOIN ordering.orderstatus os on o.OrderStatusId = os.Id
                    WHERE o.Id=@id"
                , new { id }
            );

        if (result.AsList().Count == 0)
            throw new KeyNotFoundException();

        return MapFeedbackReport(result);
    }

    public async Task<FeedbackReport> GetFeedbackReportAsync(int id)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        //TODO: Replace w/ correct query expression
        var result = await connection.QueryAsync<dynamic>(
            @"select o.[Id] as ordernumber,o.OrderDate as date, o.Description as description,
                    o.Address_City as city, o.Address_Country as country, o.Address_State as state, o.Address_Street as street, o.Address_ZipCode as zipcode,
                    os.Name as status, 
                    oi.ProductName as productname, oi.Units as units, oi.UnitPrice as unitprice, oi.PictureUrl as pictureurl
                    FROM ordering.Orders o
                    LEFT JOIN ordering.Orderitems oi ON o.Id = oi.orderid 
                    LEFT JOIN ordering.orderstatus os on o.OrderStatusId = os.Id
                    WHERE o.Id=@id"
                , new { id }
            );

        if (result.AsList().Count == 0)
            throw new KeyNotFoundException();

        return MapFeedbackReport(result);
    }

    private FeedbackReport MapFeedbackReport(dynamic result)
    {
        return new FeedbackReport() { Description = "", FirstName = "", LastName = "" };
    }
}
