namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Application.Commands;

public class CreateFeedbackReportCommandHandler : IRequestHandler<CreateFeedbackReportCommand, bool>
{
    public Task<bool> Handle(CreateFeedbackReportCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
