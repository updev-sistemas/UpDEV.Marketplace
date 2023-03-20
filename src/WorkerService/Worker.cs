using UpDEV.Marketplace.Domains.Entities;
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
                    var brand = new BrandEntity
                    {
                        Name = "Coca Cola",
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                    };

                    await session.SaveOrUpdateAsync(brand).ConfigureAwait(false);
                    await session.FlushAsync().ConfigureAwait(false);

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