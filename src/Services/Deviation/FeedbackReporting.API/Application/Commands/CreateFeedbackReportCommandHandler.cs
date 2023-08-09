

using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Model.DTO;

namespace Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Application.Commands;

public class CreateFeedbackReportCommandHandler : IRequestHandler<CreateFeedbackReportCommand, FeedbackReportDTO>
{
    private readonly IFeedbackReportRepository _orderRepository;
    private readonly IFeedbackReportReplyMethodRepository _replyMethodRepository;
    //private readonly IIdentityService _identityService;
    private readonly IMediator _mediator;
    private readonly IFeedbackReportingIntegrationEventService _orderingIntegrationEventService;
    private readonly ILogger<CreateFeedbackReportCommandHandler> _logger;

    public CreateFeedbackReportCommandHandler(IFeedbackReportRepository orderRepository,
        IFeedbackReportReplyMethodRepository replyMethodRepository,
        IMediator mediator,
        IFeedbackReportingIntegrationEventService orderingIntegrationEventService,
        ILogger<CreateFeedbackReportCommandHandler> logger)
    {
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        _replyMethodRepository = replyMethodRepository;
        //_identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _orderingIntegrationEventService = orderingIntegrationEventService ?? throw new ArgumentNullException(nameof(orderingIntegrationEventService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<FeedbackReportDTO> Handle(CreateFeedbackReportCommand request, CancellationToken cancellationToken)
    {
        var replyMethods = await _replyMethodRepository.GetAsync();
        // Add Integration event to clean the basket
        //var orderStartedIntegrationEvent = new OrderStartedIntegrationEvent(message.UserId);
        //await _orderingIntegrationEventService.AddAndSaveEventAsync(orderStartedIntegrationEvent);

        // Add/Update the Buyer AggregateRoot
        // DDD patterns comment: Add child entities and value-objects through the Order Aggregate-Root
        // methods and constructor so validations, invariants and business logic 
        // make sure that consistency is preserved across the whole aggregate
        //var address = new Address(message.Street, message.City, message.State, message.Country, message.ZipCode);
        var feedbackReport = new FeedbackReport(
            city: request.City,
            phone: request.Phone,
            middleName: request.MiddleName,
            lastName: request.LastName,
            firstName: request.FirstName,
            pOBox: request.POBox,
            email: request.Email,
            description: request.Description,
            createdBy: request.CreatedBy,
            country: request.Country,
            postalCode: request.PostalCode,
            street: request.Street,
            updatedBy: request.UpdatedBy,
            workPhone: request.WorkPhone
            );

        foreach(var rm in request.ReplyMethods)
        {
            var repM = replyMethods.SingleOrDefault(r => r.Id == rm.Id);
            feedbackReport.AddReplyMethod(repM);
        }

        _logger.LogInformation("Creating FeedbackReport - FeedbackReport: {@FeedbackReport}", feedbackReport);

        _orderRepository.Add(feedbackReport);

        await _orderRepository.UnitOfWork
            .SaveEntitiesAsync(cancellationToken);

        var createdReport = await _orderRepository.GetAsync(feedbackReport.Id);

        return new FeedbackReportDTO()
        {
            Id = createdReport.Id,
            City = createdReport.City,
            Created = createdReport.Created,
            Country = createdReport.Country,
            CreatedBy = createdReport.CreatedBy,
            Description = createdReport.Description,
            Email = createdReport.Email,
            FirstName = createdReport.FirstName,
            IsReadOnly = createdReport.IsReadOnly,
            LastName = createdReport.LastName,
            MiddleName = createdReport.MiddleName,
            Phone = createdReport.Phone,
            POBox = createdReport.POBox,
            PostalCode = createdReport.PostalCode,
            PublicId = createdReport.PublicId,
            ReplyMethods = createdReport.ReplyMethods,
            Street = createdReport.Street,
            Updated = createdReport.Updated,
            UpdatedBy = createdReport.UpdatedBy,
            WorkPhone = createdReport.WorkPhone
        };
    }
}
