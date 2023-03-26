using UpDEV.Marketplace.Infrastructures.DatabaseFactory.Configurations;
using WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDatabaseFactory(hostContext.Configuration, "postgres");

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
