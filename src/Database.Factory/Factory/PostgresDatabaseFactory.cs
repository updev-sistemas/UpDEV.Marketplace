using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using System.Reflection;
using FluentNHibernate.Conventions.Helpers;
using NHibernate.Tool.hbm2ddl;

namespace UpDEV.Marketplace.Infrastructures.DatabaseFactory.Factory
{
    public sealed class PostgresDatabaseFactory : IDatabaseFactory
    {
        private static ISessionFactory? _factory = null;

        public PostgresDatabaseFactory(string connectionString)
            => Initialize(connectionString);

        private void Initialize(string connectionString)
        {
            if (_factory == null && !string.IsNullOrEmpty(connectionString) && !string.IsNullOrWhiteSpace(connectionString))
            {
                _factory = Fluently
                    .Configure()
                    .Database(PostgreSQLConfiguration.Standard.ConnectionString(connectionString!).ShowSql())
                    .Mappings(m =>
                    {
                        m.HbmMappings.AddFromAssembly(Assembly.Load("UpDEV.Marketplace.Infrastructures.Database.Authority.Mapping"));
                        m.HbmMappings.AddFromAssembly(Assembly.Load("UpDEV.Marketplace.Infrastructures.Database.Catalog.Mapping"));
                        m.HbmMappings.AddFromAssembly(Assembly.Load("UpDEV.Marketplace.Infrastructures.Database.CRM.Mapping"));
                        m.HbmMappings.AddFromAssembly(Assembly.Load("UpDEV.Marketplace.Infrastructures.Database.Inbound.Mapping"));
                        m.HbmMappings.AddFromAssembly(Assembly.Load("UpDEV.Marketplace.Infrastructures.Database.Miscelaneas.Mapping"));
                        m.HbmMappings.AddFromAssembly(Assembly.Load("UpDEV.Marketplace.Infrastructures.Database.Outbound.Mapping"));
                        m.HbmMappings.AddFromAssembly(Assembly.Load("UpDEV.Marketplace.Infrastructures.Database.TaxBookkeeping.Mapping"));
                        m.HbmMappings.AddFromAssembly(Assembly.Load("UpDEV.Marketplace.Infrastructures.Database.WMS.Mapping"));
                    })
                    .ExposeConfiguration(cfg =>
                    {
                        /**
                         * Generate new database
                         */
                        new SchemaExport(cfg).Execute(true, true, false);
                        cfg.SetProperty("adonet.batch_size", "5");
                        cfg.SetProperty("dialect", "NHibernate.Dialect.PostgreSQLDialect");
                    })
                    .BuildSessionFactory();
            }
        }

        public ISessionFactory GetFactory()
            => _factory!;

        public ISession OpenSession()
            => GetFactory().OpenSession();

        public void Dispose()
        {
            if (!(bool)_factory?.IsClosed)
            {
                _factory?.Close();
            }

            _factory?.Dispose();
        }
    }
}
