using CoacehlTraining.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using GV.DomainModel.SharedKernel.Settings;
using System.Data.SqlClient;
using GV.DomainModel.SharedKernel.Interfaces;

namespace CoacehlTraining.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddMariaDbContext(this IServiceCollection services, string connectionString, string environmentVariableName = "coacehl_mariadb_dev")
        {
            var connStringBuilder = new MySqlConnectionStringBuilder
            {
                ConnectionString = connectionString
            };
            if (string.IsNullOrEmpty(connStringBuilder.Password))
            {
                connStringBuilder.Password = EnvironmentManagement.GetVariable(environmentVariableName);
                connectionString = connStringBuilder.ConnectionString;
            }
            services.AddDbContext<MariaDbContext>(options => options.UseMySql(connectionString, ServerVersion.Parse("10.7.3-mariadb")));
        }

        public static void AddSqlServerDbContext(this IServiceCollection services, string connectionString, string environmentVariableName = "coacehl_sqlserver_dev")
        {
            var connStringBuilder = new SqlConnectionStringBuilder
            {
                ConnectionString = connectionString
            };
            if (string.IsNullOrEmpty(connStringBuilder.Password))
            {
                connStringBuilder.Password = EnvironmentManagement.GetVariable(environmentVariableName);
                connectionString = connStringBuilder.ConnectionString;
            }
            //services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(connectionString));
        }

        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IAppLogger<>), typeof(LoggerService<>));
            services.AddScoped(typeof(IRepository<>), typeof(MariaDbRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(MariaDbRepository<>));
        }
    }
}
