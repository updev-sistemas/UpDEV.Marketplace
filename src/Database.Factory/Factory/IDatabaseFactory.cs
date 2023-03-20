using NHibernate;

namespace UpDEV.Marketplace.Infrastructures.DatabaseFactory.Factory
{
    public interface IDatabaseFactory
    {
        ISessionFactory GetFactory();
        ISession OpenSession();
    }
}
