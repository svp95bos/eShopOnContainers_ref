
using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Queries;

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Controllers;

[Route("api/v1/[controller]")]
//[Authorize]
[ApiController]
public class FeedbackReportsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IFeedbackReportQueries _feedbackReportQueries;
    //private readonly IIdentityService _identityService;
    private readonly ILogger<FeedbackReportsController> _logger;

    public FeedbackReportsController(
        IMediator mediator,
        IFeedbackReportQueries feedbackReportQueries,
        //IIdentityService identityService,
        ILogger<FeedbackReportsController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _feedbackReportQueries = feedbackReportQueries ?? throw new ArgumentNullException(nameof(feedbackReportQueries));
        //_identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [Route("{feedbackReportId:guid}")]
    [HttpGet]
    [ProducesResponseType(typeof(Queries.FeedbackReport), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Queries.FeedbackReport>> GetOrderAsync(Guid feedbackReportId)
    {
        try
        {
            //Todo: It's good idea to take advantage of GetOrderByIdQuery and handle by GetCustomerByIdQueryHandler
            //var order customer = await _mediator.Send(new GetOrderByIdQuery(orderId));
            var order = await _feedbackReportQueries.GetFeedbackReportAsync(feedbackReportId);

            return order;
        }
        catch
        {
            return NotFound();
        }
    }
}
