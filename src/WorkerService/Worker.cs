using UpDEV.Marketplace.Domains.CRM.Entities;
using UpDEV.Marketplace.Infrastructures.DatabaseFactory.Factory;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IDatabaseFactory? _factory;

        public Worker(ILogger<Worker> logger, IDatabaseFactory factory)
        {
            _logger = logger;
            this._factory = factory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var session = _factory!.OpenSession();
                try
                {
                    var person = new PersonEntity
                    {
                        Birthday = new DateTime(1989,10,27),
                        Email = "falecomoantonio@live.com",
                        Name = "Antonio José",
                        Observation = "Novo Cliente Teste",
                        Phone1 = "(88) 9 8143-1663",
                        Phone2 = "(88) 2149-0005",
                        Surname = "Barros",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    };

                    var customer = new CustomerEntity
                    {
                        CreatedAt = DateTime.Now,   
                        UpdatedAt = DateTime.Now,
                        Person = person
                    };

                    var supplier = new SupplierEntity
                    {
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        Person = person
                    };

                    await session.SaveOrUpdateAsync(supplier, stoppingToken).ConfigureAwait(false);
                    await session.SaveOrUpdateAsync(customer, stoppingToken).ConfigureAwait(false);
                    await session.FlushAsync(stoppingToken).ConfigureAwait(false);

                    _logger!.LogInformation("Deu certo.");
                }
                catch (Exception ex)
                {
                    _logger!.LogError(ex.Message);
                    _ = ex;
                }

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}