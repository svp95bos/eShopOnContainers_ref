using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Application.Commands;
using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Infrastructure.Repositories;
using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.IntegrationEvents;
using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Model.DTO;

namespace FeedbackReporting.API.UnitTests.Application;
public class CreateFeedbackReportCommandHandlerTest
{
    private readonly Mock<IFeedbackReportRepository> _orderRepositoryMock;
    //private readonly Mock<IIdentityService> _identityServiceMock;
    private readonly Mock<IMediator> _mediator;
    private readonly Mock<IFeedbackReportingIntegrationEventService> _orderingIntegrationEventService;

    public CreateFeedbackReportCommandHandlerTest()
    {
        _orderRepositoryMock = new Mock<IFeedbackReportRepository>();
        //_identityServiceMock = new Mock<IIdentityService>();
        _orderingIntegrationEventService = new Mock<IFeedbackReportingIntegrationEventService>();
        _mediator = new Mock<IMediator>();
    }

    [Fact]
    public async Task Handle_return_false_if_order_is_not_persisted()
    {
        var buyerId = "1234";

        var fakeOrderCmd = FakeOrderRequestWithBuyer(new Dictionary<string, object>
        { ["cardExpiration"] = DateTime.Now.AddYears(1) });

        _orderRepositoryMock.Setup(orderRepo => orderRepo.Add(It.IsAny<Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API.Model.FeedbackReport>()))
            .Returns(Task.FromResult<FeedbackReportDTO>(FakeReportDTO()));

        _orderRepositoryMock.Setup(buyerRepo => buyerRepo.UnitOfWork.SaveChangesAsync(default))
            .Returns(Task.FromResult(1));

        

        var LoggerMock = new Mock<ILogger<CreateFeedbackReportCommandHandler>>();
        //Act
        var handler = new CreateFeedbackReportCommandHandler(_orderRepositoryMock.Object, _mediator.Object, _orderingIntegrationEventService.Object, LoggerMock.Object);
        var cltToken = new System.Threading.CancellationToken();
        var result = await handler.Handle(fakeOrderCmd, cltToken);

        //Assert
        Assert.False(result);
    }

    private FeedbackReport FakeReportDTO()
    {
        return new FeedbackReport();
    }

    private CreateFeedbackReportCommand FakeOrderRequestWithBuyer(Dictionary<string, object> args = null)
    {
        return new CreateFeedbackReportCommand(
            new List<FeedbackReportReplyMethodDTO>(),
            publicId: args != null && args.ContainsKey("publicId") ? (int)args["publicId"] : 99,
            firstName: args != null && args.ContainsKey("firstName") ? (string)args["firstName"] : null,
            middleName: args != null && args.ContainsKey("middleName") ? (string)args["middleName"] : null,
            lastName: args != null && args.ContainsKey("lastName") ? (string)args["lastName"] : null,
            pOBox: args != null && args.ContainsKey("pOBox") ? (string)args["pOBox"] : null,
            street: args != null && args.ContainsKey("street") ? (string)args["street"] : null,
            postalCode: args != null && args.ContainsKey("postalCode") ? (string)args["postalCode"] : null,
            city: args != null && args.ContainsKey("city") ? (string)args["city"] : null,
            country: args != null && args.ContainsKey("country") ? (string)args["country"] : null,
            phone: args != null && args.ContainsKey("phone") ? (string)args["phone"] : null,
            workPhone: args != null && args.ContainsKey("workPhone") ? (string)args["workPhone"] : null,
            email: args != null && args.ContainsKey("email") ? (string)args["email"] : null,
            description: args != null && args.ContainsKey("description") ? (string)args["description"] : null,
            createdBy: args != null && args.ContainsKey("createdBy") ? (Guid)args["createdBy"] : Guid.NewGuid(),
            updatedBy: args != null && args.ContainsKey("updatedBy") ? (Guid)args["updatedBy"] : Guid.NewGuid(),
            isReadOnly: args != null && args.ContainsKey("isReadOnly") ? (bool)args["isReadOnly"] : false);
    }
}

