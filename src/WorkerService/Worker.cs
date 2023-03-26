using NHibernate;
using System.Xml.Linq;
using UpDEV.Marketplace.Domains.CRM.Entities;
using UpDEV.Marketplace.Domains.Miscelaneas.Entities;
using UpDEV.Marketplace.Infrastructures.DatabaseFactory.Factory;
using static NHibernate.Engine.Query.CallableParser;

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
                    var suppliers = session.Query<SupplierEntity>().ToArray();
                    _ = suppliers;

                    var people = session.Query<PersonEntity>().ToArray();
                    _ = people;

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