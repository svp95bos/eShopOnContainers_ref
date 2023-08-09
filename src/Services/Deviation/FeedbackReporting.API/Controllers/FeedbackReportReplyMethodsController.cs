
using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Queries;

using FeedbackReportReplyMethod = Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Queries.FeedbackReportReplyMethod;

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Controllers;

[Route("api/v1/[controller]")]
//[Authorize]
[ApiController]
public class FeedbackReportReplyMethodsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IFeedbackReportQueries _feedbackReportQueries;
    //private readonly IIdentityService _identityService;
    private readonly ILogger<FeedbackReportReplyMethodsController> _logger;

    public FeedbackReportReplyMethodsController(
        IMediator mediator,
        IFeedbackReportQueries feedbackReportQueries,
        //IIdentityService identityService,
        ILogger<FeedbackReportReplyMethodsController> logger)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _feedbackReportQueries = feedbackReportQueries ?? throw new ArgumentNullException(nameof(feedbackReportQueries));
        //_identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<FeedbackReportReplyMethod>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<FeedbackReportReplyMethod>>> GetFeedbackReportReplyMethodsAsync()
    {
        var replyMethods = await _feedbackReportQueries.GetFeedbackReportReplyMethodsAsync();

        return Ok(replyMethods);
    }
}
