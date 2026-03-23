
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



namespace Infrastructure.Persistence
{
    public class AppDbContextOptionsSetup
    {
        public static void Configure(DbContextOptionsBuilder options,IConfiguration? configuration = null)
		{
			var connectionString = configuration?.GetConnectionString("DefaultConnection");
			if(string.IsNullOrEmpty(connectionString))
			{
			
			var dbHost = Environment.GetEnvironmentVariable("MYSQL_HOST") ?? "mysql";
			var dbPort = Environment.GetEnvironmentVariable("MYSQL_PORT") ?? "3308";
			var dbName = Environment.GetEnvironmentVariable("MYSQL_NAME") ?? "pharmacy_mysql";
			var dbUser = Environment.GetEnvironmentVariable("MYSQL_USER") ?? "mysql_user";
			var dbPassword = Environment.GetEnvironmentVariable("MYSQL_PASSWORD") ?? "123456";
			connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword}";

			}

			  options.UseMySql(
            connectionString,
            new MySqlServerVersion(new Version(8, 4, 8)),
            mysqlOptions =>
            {
                mysqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null);
            });
			
		}
    }
}