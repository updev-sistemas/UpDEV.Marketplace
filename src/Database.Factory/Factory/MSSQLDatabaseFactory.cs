using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using System.Reflection;
using FluentNHibernate.Conventions.Helpers;
using NHibernate.Tool.hbm2ddl;

namespace UpDEV.Marketplace.Infrastructures.DatabaseFactory.Factory
{
    public sealed class MSSQLDatabaseFactory : IDatabaseFactory
    {
        private static ISessionFactory? _factory = null;

        public MSSQLDatabaseFactory(string connectionString)
            => Initialize(connectionString);

        private void Initialize(string connectionString)
        {
            if (_factory == null && !string.IsNullOrEmpty(connectionString) && !string.IsNullOrWhiteSpace(connectionString))
            {
                _factory = Fluently
                    .Configure()
                    .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString!).ShowSql())
                    .Mappings(m =>
                    {
                        m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly());
                        //m.FluentMappings.Conventions.Setup(m => m.Add(AutoImport.Never()))
                        //                .AddFromAssembly(typeof(CountryMap).Assembly)
                        //                .AddFromAssembly(typeof(PersonMap).Assembly);

                    })
                    .ExposeConfiguration(cfg =>
                    {
                        /**
                         * Generate new database
                         */
                        // new SchemaUpdate(cfg).Execute(true, true);
                        new SchemaExport(cfg).Execute(true, true, false);
                        cfg.SetProperty("adonet.batch_size", "5");
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
