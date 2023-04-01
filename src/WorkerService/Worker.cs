using UpDEV.Marketplace.Infrastructures.DatabaseRepository.UnitOfWork.Contracts;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IMiscelaneasUOW? _repository;

        public Worker(ILogger<Worker> logger, IMiscelaneasUOW repository)
        {
            _logger = logger;
            this._repository = repository;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var itemRecovery = await this._repository!
                                                    .City
                                                    .FindSingleAsync(p => p.Name == "Quixeramobim", stoppingToken)
                                                    .ConfigureAwait(false);   
                    _ = itemRecovery;

                    var cities = await this._repository!.City!.NearbyCitiesByLocation(21.3111111f, 21.3121f, 100f);
                    _ = cities;

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