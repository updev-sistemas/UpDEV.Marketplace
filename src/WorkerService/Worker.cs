using UpDEV.Marketplace.Domains.Catalog.Entities;
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
                    var itemRecovery = session.Query<ItemEntity>().FirstOrDefault();
                    _ = itemRecovery;

                    var basicUnit = new UnitEntity
                    {
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,    
                        Name = "Unidade",
                        Sigla = "UNI"
                    };

                    var salesUnit = new UnitEntity
                    {
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                        Name = "Caixa",
                        Sigla = "CX"
                    };

                    var group = new GroupEntity
                    {
                        CreatedAt= DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                        Name = "Grupo Geral 1",
                        Description = "Grupo Geral 1"
                    };

                    var section = new SectionEntity
                    {
                        Description = "Seção Geral 1",
                        IsVirtual = false,
                        Name = "Seção Geral",
                        TypeEnvironment = UpDEV.Marketplace.Domains.Common.Enumerables.ProductSectionType.DRY,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                    };

                    var category = new CategoryEntity
                    {
                        Description = "Categoria Geral 1",
                        Name = "Categoria Geral 1",
                        Section = section,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                    };

                    var subcategory = new SubcategoryEntity
                    {
                        Name = "Subcategoria Geral 1",
                        Description = "Subcategoria geral 1",
                        Category = category,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                    };

                    var item = new ItemEntity
                    {
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                        IsService = false,
                        Code = "1200",
                        Name = "Produto Padrão 1",
                        Description = "Produto Padrão 1",
                        HtmlDescription = "<p>Produto Padrão 1</p>",
                        Images = "image1.png, image2.png",
                        BasicUnit = basicUnit,
                        SalesUnit = salesUnit,
                        Group = group,
                        Subcategory = subcategory,
                        IsVirtual = false,
                        Thumbnail = "img-default.png",
                        ToOrder = false,
                        AccceptedToOrder = false,
                        ControlledProduction = false,
                        Properties = default
                    };

                    var list = new List<ItemPropertyEntity>()
                    {
                        new ItemPropertyEntity
                        {
                            Item = item,
                            IsMandatory = false,
                            Key = "Property A",
                            Value = "Property A",
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow,
                        },
                        new ItemPropertyEntity
                        {
                            Item = item,
                            IsMandatory = false,
                            Key = "Property B",
                            Value = "Property B",
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow,
                        },
                        new ItemPropertyEntity
                        {
                            Item = item,
                            IsMandatory = false,
                            Key = "Property C",
                            Value = "Property C",
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow,
                        },
                    };

                    await session.SaveOrUpdateAsync(basicUnit, stoppingToken).ConfigureAwait(false);
                    await session.SaveOrUpdateAsync(salesUnit, stoppingToken).ConfigureAwait(false);
                    await session.SaveOrUpdateAsync(group, stoppingToken).ConfigureAwait(false);
                    await session.SaveOrUpdateAsync(section, stoppingToken).ConfigureAwait(false);
                    await session.SaveOrUpdateAsync(category, stoppingToken).ConfigureAwait(false);
                    await session.SaveOrUpdateAsync(subcategory, stoppingToken).ConfigureAwait(false);
                    await session.SaveOrUpdateAsync(item, stoppingToken).ConfigureAwait(false);


                    foreach (var prop in list)
                    {
                        await session.SaveOrUpdateAsync(prop, stoppingToken).ConfigureAwait(false);
                    }

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