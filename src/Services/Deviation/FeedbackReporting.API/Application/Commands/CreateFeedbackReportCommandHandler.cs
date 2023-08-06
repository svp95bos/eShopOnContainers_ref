namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Application.Commands;

public class CreateFeedbackReportCommandHandler
{
}

public record FeedbackReportDTO
{
    public IEnumerable<FeedbackReportReplyMethodDTO> ReplyMethods { get; init; }
    public decimal Total { get; init; }

    public static OrderDraftDTO FromOrder(Order order)
    {
        return new OrderDraftDTO()
        {
            OrderItems = order.OrderItems.Select(oi => new OrderItemDTO
            {
                Discount = oi.GetCurrentDiscount(),
                ProductId = oi.ProductId,
                UnitPrice = oi.GetUnitPrice(),
                PictureUrl = oi.GetPictureUri(),
                Units = oi.GetUnits(),
                ProductName = oi.GetOrderItemProductName()
            }),
            Total = order.GetTotal()
        };
    }
}

public record FeedbackReportReplyMethodDTO
{
    public int Id { get; init; }
    public string Name { get; init; }
    public bool IsEnabled { get; init; }
}
