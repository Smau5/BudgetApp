using BudgetApp.Core.Interfaces;
using BudgetApp.Infrastructure.Persistence;
using BudgetApp.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SampleEndpointApp", Version = "v1" });
    c.EnableAnnotations();
});
builder.Services.AddDbContext<AppDbContext>(builderOptions =>
{
    var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
    string connectionString;
    if (databaseUrl is not null)
    {
        var databaseUri = new Uri(databaseUrl);
        var userInfo = databaseUri.UserInfo.Split(':');

        var connectionStringBuilder = new NpgsqlConnectionStringBuilder
        {
            Host = databaseUri.Host,
            Port = databaseUri.Port,
            Username = userInfo[0],
            Password = userInfo[1],
            Database = databaseUri.LocalPath.TrimStart('/')
        };
        connectionString = connectionStringBuilder.ToString();
    }
    else
    {
        connectionString = builder.Configuration["Database:ConnectionString"];
    }

    builderOptions.UseNpgsql(
        connectionString,
        options => options.MigrationsAssembly("BudgetApp.Infrastructure"));
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<IBudgetRepository, BudgetRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();