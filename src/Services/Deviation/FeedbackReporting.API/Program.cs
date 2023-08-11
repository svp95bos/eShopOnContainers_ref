

using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.API;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddGrpc();
builder.Services.AddControllers();

// Application specific services
builder.Services.AddHealthChecks(builder.Configuration);
builder.Services.AddDbContexts(builder.Configuration);
builder.Services.AddApplicationOptions(builder.Configuration);
builder.Services.AddIntegrationServices();
builder.Services.AddRepositoryServices();

//builder.Services.AddTransient<OrderStatusChangedToAwaitingValidationIntegrationEventHandler>();
//builder.Services.AddTransient<OrderStatusChangedToPaidIntegrationEventHandler>();

var app = builder.Build();

app.UseServiceDefaults();

app.MapControllers();
app.MapGrpcService<FeedbackReportingService>();

var eventBus = app.Services.GetRequiredService<IEventBus>();

//eventBus.Subscribe<OrderStatusChangedToAwaitingValidationIntegrationEvent, OrderStatusChangedToAwaitingValidationIntegrationEventHandler>();
//eventBus.Subscribe<OrderStatusChangedToPaidIntegrationEvent, OrderStatusChangedToPaidIntegrationEventHandler>();

// REVIEW: This is done for development ease but shouldn't be here in production
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<FeedbackReportingContext>();
    var settings = app.Services.GetService<IOptions<FeedbackReportingSettings>>();
    var logger = app.Services.GetService<ILogger<FeedbackReportingContextSeed>>();
    await context.Database.MigrateAsync();

    await new FeedbackReportingContextSeed().SeedAsync(context, app.Environment, settings, logger);
    var integrationEventLogContext = scope.ServiceProvider.GetRequiredService<IntegrationEventLogContext>();
    await integrationEventLogContext.Database.MigrateAsync();
}

await app.RunAsync();
