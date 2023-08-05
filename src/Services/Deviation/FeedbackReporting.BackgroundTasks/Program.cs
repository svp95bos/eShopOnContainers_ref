using Microsoft.eShopOnContainers.Services.Deviation.FeedbackReporting.BackgroundTasks;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
