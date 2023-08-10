
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Extensions;
using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Model.DTO;

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Controllers;

[Route("api/v1/[controller]")]
//[Authorize]
[ApiController]
public class FeedbackReportsController : ControllerBase
{
    private readonly FeedbackReportingContext _dbContext;
    private readonly ILogger<FeedbackReportsController> _logger;
    private readonly FeedbackReportingSettings _settings;
    private readonly IFeedbackReportingIntegrationEventService _feedbackIntegrationEventService;

    public FeedbackReportsController(
        FeedbackReportingContext dbContext, 
        IOptionsSnapshot<FeedbackReportingSettings> settings,
        ILogger<FeedbackReportsController> logger,
        IFeedbackReportingIntegrationEventService feedbackIntegrationEventService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _dbContext = dbContext;
        _settings = settings.Value;
        _feedbackIntegrationEventService = feedbackIntegrationEventService;

    }

    [Route("{feedbackReportId:guid}")]
    [HttpGet]
    [ProducesResponseType(typeof(PaginatedItemsViewModel<FeedbackReport>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnumerable<FeedbackReport>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaginatedItemsViewModel<FeedbackReport>>> GetFeedbackReportsAsync([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0, string ids = null)
    {
        List<FeedbackReport> itemsOnPage = new();

        long totalItems = 0;

        if (!string.IsNullOrEmpty(ids))
        {
            var feedbackReports = await GetFeedbackReportsByIdsAsync(ids);

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

        totalItems = await _dbContext.FeedbackReports
            .LongCountAsync();

        itemsOnPage = await _dbContext.FeedbackReports
            .OrderBy(c => c.Created)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItemsViewModel<FeedbackReport>(pageIndex, pageSize, totalItems, itemsOnPage);
    }

    //[HttpPost]
    //[ProducesResponseType(StatusCodes.Status201Created)]
    //public async Task<ActionResult<FeedbackReportDTO>> CreateFeedbackReportAsync([FromBody] CreateFeedbackReportCommand createFeedbackReportCommand)
    //{
    //    _logger.LogInformation(
    //        "Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
    //        createFeedbackReportCommand.GetGenericTypeName(),
    //        nameof(createFeedbackReportCommand),
    //        createFeedbackReportCommand,
    //        createFeedbackReportCommand);

    //    FeedbackReportDTO response = await _mediator.Send(createFeedbackReportCommand);

    //    return CreatedAtAction(nameof(CreateFeedbackReportAsync), response);
    //}

    private async Task<List<FeedbackReport>> GetFeedbackReportsByIdsAsync(string ids)
    {
        var numIds = ids.Split(',').Select(id => (Ok: Guid.TryParse(id, out Guid x), Value: x));

        if (!numIds.All(nid => nid.Ok))
        {
            return new List<FeedbackReport>();
        }

        var idsToSelect = numIds
            .Select(id => id.Value);

        var feedbackReports = await _dbContext.FeedbackReports.Where(ci => idsToSelect.Contains(ci.Id)).ToListAsync();

        return feedbackReports;
    }
}
