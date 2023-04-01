using UpDEV.Marketplace.Infrastructures.DatabaseFactory.Configurations;
using UpDEV.Marketplace.Infrastructures.DatabaseRepository.Extensions;
using WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDatabaseFactory(hostContext.Configuration, "postgres");

        services.RegisterRepository();

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
