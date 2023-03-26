using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UpDEV.Marketplace.Infrastructures.DatabaseFactory.Factory;

namespace UpDEV.Marketplace.Infrastructures.DatabaseFactory.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseFactory(this IServiceCollection services, IConfiguration configuration, string? context)
        {
            if (string.IsNullOrEmpty(context) || string.IsNullOrWhiteSpace(context))
                throw new Exception("Configuração de conexão com o banco é inválida.");

            var connectionString = configuration!.GetConnectionString(context);
            if (string.IsNullOrEmpty(connectionString) || string.IsNullOrWhiteSpace(connectionString))
                throw new Exception("Configuração de conexão com o banco de dados inexistente");

            if (context!.Equals("postgres",StringComparison.CurrentCultureIgnoreCase))
            {
                _ = services.AddSingleton<IDatabaseFactory, PostgresDatabaseFactory>(cfg => new PostgresDatabaseFactory(connectionString!));
            }
            else if (context!.Equals("mysql", StringComparison.CurrentCultureIgnoreCase))
            {
                _ = services.AddSingleton<IDatabaseFactory, MySQLDatabaseFactory>(cfg => new MySQLDatabaseFactory(connectionString!));
            }
            else if (context!.Equals("mssql", StringComparison.CurrentCultureIgnoreCase))
            {
                _ = services.AddSingleton<IDatabaseFactory, MSSQLDatabaseFactory>(cfg => new MSSQLDatabaseFactory(connectionString!));
            }
            else
            {
                throw new Exception("Ainda não existe configuração para o banco especificado.");
            }
        }
    }
}
