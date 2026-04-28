using Api.Middleware;
using Application.Interfaces;
using Application.Services;
using Application.Validators;
using Domain.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using Polly;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<UserCreateDtoValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserService,UserService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
	 AppDbContextOptionsSetup.Configure(options, builder.Configuration);
}
);

builder.Services.AddCors(

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
		DbSeed.SeedAsync(db).GetAwaiter().GetResult();
    });
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
