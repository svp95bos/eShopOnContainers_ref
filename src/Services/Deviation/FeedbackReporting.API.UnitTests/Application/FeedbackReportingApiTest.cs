
namespace FeedbackReporting.API.UnitTests.Application;
public class FeedbackReportingApiTest
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<IFeedbackReportQueries> _feedbackReportQueriesMock;
    // private readonly Mock<IIdentityService> _identityServiceMock;
    private readonly Mock<ILogger<FeedbackReportsController>> _loggerMock;

    public FeedbackReportingApiTest()
    {
        _mediatorMock = new Mock<IMediator>();
        _feedbackReportQueriesMock = new Mock<IFeedbackReportQueries>();
        //_identityServiceMock = new Mock<IIdentityService>();
        _loggerMock = new Mock<ILogger<FeedbackReportsController>>();
    }

    [Fact]
    public async Task Get_feedbackReport_success()
    {
        // Arrange
        var fakeReportId = Guid.NewGuid();
        var fakeDynamicResult = new FeedbackReport();

        _feedbackReportQueriesMock.Setup(x => x.GetFeedbackReportAsync(It.IsAny<Guid>()))
            .Returns(Task.FromResult(fakeDynamicResult));

        //Act
        var feedbackReportReplyMethodsController = new FeedbackReportsController(_mediatorMock.Object, _feedbackReportQueriesMock.Object,  _loggerMock.Object);
        var actionResult = await feedbackReportReplyMethodsController.GetFeedbackReportsAsync(fakeReportId);

        //Assert
        Assert.Same(actionResult.Value, fakeDynamicResult);
    }
}
