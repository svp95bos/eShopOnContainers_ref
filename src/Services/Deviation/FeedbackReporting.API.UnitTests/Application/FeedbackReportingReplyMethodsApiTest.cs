
namespace FeedbackReporting.API.UnitTests.Application;
public class FeedbackReportingReplyMethodsApiTest
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<IFeedbackReportQueries> _feedbackReportQueriesMock;
    // private readonly Mock<IIdentityService> _identityServiceMock;
    private readonly Mock<ILogger<FeedbackReportReplyMethodsController>> _loggerMock;

    public FeedbackReportingReplyMethodsApiTest()
    {
        _mediatorMock = new Mock<IMediator>();
        _feedbackReportQueriesMock = new Mock<IFeedbackReportQueries>();
        //_identityServiceMock = new Mock<IIdentityService>();
        _loggerMock = new Mock<ILogger<FeedbackReportReplyMethodsController>>();
    }

    [Fact]
    public async Task Get_feedbackReportReplyMethods_success()
    {
        // Arrange
        IEnumerable<FeedbackReportReplyMethod> fakeDynamicResult = null;

        _feedbackReportQueriesMock.Setup(x => x.GetFeedbackReportReplyMethodsAsync())
            .Returns(Task.FromResult(fakeDynamicResult));

        //Act
        var feedbackReportReplyMethodsController = new FeedbackReportReplyMethodsController(_mediatorMock.Object, _feedbackReportQueriesMock.Object,  _loggerMock.Object);
        var actionResult = await feedbackReportReplyMethodsController.GetFeedbackReportReplyMethodsAsync();

        //Assert
        Assert.Same(actionResult.Value, fakeDynamicResult);
    }
}
