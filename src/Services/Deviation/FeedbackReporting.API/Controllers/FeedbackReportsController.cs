
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Extensions;
using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Model.DTO;

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Controllers;

[Route("api/v1/[controller]")]
//[Authorize]
[ApiController]
public class FeedbackReportsController : ControllerBase
{
    private readonly IFeedbackReportRepository _repository;
    private readonly ILogger<FeedbackReportsController> _logger;
    private readonly FeedbackReportingSettings _settings;
    private readonly IFeedbackReportingIntegrationEventService _feedbackIntegrationEventService;

    public FeedbackReportsController(
        IFeedbackReportRepository repository,
        IOptionsSnapshot<FeedbackReportingSettings> settings,
        ILogger<FeedbackReportsController> logger,
        IFeedbackReportingIntegrationEventService feedbackIntegrationEventService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _repository = repository;
        _settings = settings.Value;
        _feedbackIntegrationEventService = feedbackIntegrationEventService;

    }

    [Route("reports")]
    [HttpGet]
    [ProducesResponseType(typeof(PaginatedItemsViewModel<FeedbackReport>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnumerable<FeedbackReport>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginatedItemsViewModel<FeedbackReport>>> GetFeedbackReportsAsync([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0, string feedbackReportIds = null)
    {
        List<FeedbackReport> itemsOnPage = new();

        long totalItems = 0;

        if (!string.IsNullOrEmpty(feedbackReportIds))
        {
            var feedbackReports = await GetFeedbackReportsByIdsAsync(feedbackReportIds);

            if (!feedbackReports.Any())
            {
                return BadRequest("ids value invalid. Must be comma-separated list of numbers");
            }

            totalItems = feedbackReports.Count;

            itemsOnPage = feedbackReports
               .OrderBy(c => c.Created)
               .Skip(pageSize * pageIndex)
               .Take(pageSize).ToList();

            return new PaginatedItemsViewModel<FeedbackReport>(pageIndex, pageSize, totalItems, itemsOnPage);

        }

        totalItems = (await _repository.GetAsync()).LongCount();


        var allItemsOnPage = (await _repository.GetAsync()).ToList();

        
        itemsOnPage = allItemsOnPage
            .OrderBy(c => c.Created)
            .Skip(pageSize * pageIndex)
            .Take(pageSize).ToList();

        return new PaginatedItemsViewModel<FeedbackReport>(pageIndex, pageSize, totalItems, itemsOnPage);
    }

    [Route("reports")]
    [HttpPost]
    [ProducesResponseType(typeof(FeedbackReportDTO), StatusCodes.Status201Created)]
    public async Task<ActionResult> CreateFeedbackReportAsync([FromBody] FeedbackReportDTO feedbackData, CancellationToken cancellationToken = default)
    {
        var item = new FeedbackReport(
            firstName: feedbackData.FirstName,
            middleName: feedbackData.MiddleName,
            lastName: feedbackData.LastName,
            pOBox: feedbackData.POBox,
            street: feedbackData.Street,
            postalCode: feedbackData.PostalCode,
            city: feedbackData.City,
            country: feedbackData.Country,
            phone: feedbackData.Phone,
            workPhone: feedbackData.WorkPhone,
            email: feedbackData.Email,
            description: feedbackData.Description,
            createdBy: Guid.Empty,
            updatedBy: Guid.Empty
            );

        _repository.Add(item);
        await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return CreatedAtAction(nameof(CreateFeedbackReportAsync), new { id = item.Id }, null);
    }

    private async Task<List<FeedbackReport>> GetFeedbackReportsByIdsAsync(string ids)
    {
        var numIds = ids.Split(',').Select(id => (Ok: Guid.TryParse(id, out Guid x), Value: x));

        if (!numIds.All(nid => nid.Ok))
        {
            return new List<FeedbackReport>();
        }

        var idsToSelect = numIds
            .Select(id => id.Value);

        var feedbackReports = await _repository.GetAsync(idsToSelect.ToList());

        return feedbackReports.ToList();
    }
}
