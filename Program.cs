using Microsoft.EntityFrameworkCore;
using pharmacy_api.Context;
using Polly;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbHost = Environment.GetEnvironmentVariable("MYSQL_HOST") ?? "localhost";
var dbPort = Environment.GetEnvironmentVariable("MYSQL_PORT") ?? "3308";
var dbName = Environment.GetEnvironmentVariable("MYSQL_NAME") ?? "pharmacy_mysql";
var dbUser = Environment.GetEnvironmentVariable("MYSQL_USER") ?? "mysql_user";
var dbPassword = Environment.GetEnvironmentVariable("MYSQL_PASSWORD") ?? "123456";

var connectionString = $"Host={dbHost};Port={dbPort};Database={dbName};Username={dbUser};Password={dbPassword}";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        connectionString,
         new MySqlServerVersion(new Version(8, 4, 8)),
        mysqlOptions =>
        {
            mysqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorNumbersToAdd: null
            );
        }
    )
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    var retryPolicy = Policy
        .Handle<Exception>()
        .WaitAndRetry(
            retryCount: 5,
            sleepDurationProvider: _ => TimeSpan.FromSeconds(5)
        );

    retryPolicy.Execute(() =>
    {
        db.Database.Migrate();
    });
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
