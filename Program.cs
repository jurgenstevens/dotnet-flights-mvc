using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Logging;
using MvcFlight.Data;
using MvcFlight.Models;
using MvcMFlight.Models;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);


// Add database context and cache
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<MvcFlightContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("MvcFlightContext") ?? throw new InvalidOperationException("Connection string 'MvcFlightContext' not found.")));
}
else
{
    var postgresConnection = Environment.GetEnvironmentVariable("AZURE_POSTGRESQL_CONNECTIONSTRING")
        ?? builder.Configuration.GetConnectionString("AZURE_POSTGRESQL_CONNECTIONSTRING");

    builder.Services.AddDbContext<MvcFlightContext>(options =>
        options.UseNpgsql(postgresConnection));

    var redisConnection = Environment.GetEnvironmentVariable("AZURE_REDIS_CONNECTIONSTRING")
        ?? builder.Configuration.GetConnectionString("AZURE_REDIS_CONNECTIONSTRING");

    builder.Services.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = redisConnection;
        options.InstanceName = "MvcFlightApp";
    });
}

// if(builder.Environment.IsDevelopment())
// {
//     builder.Services.AddDbContext<MvcFlightContext>(options =>
//         options.UseSqlite(builder.Configuration.GetConnectionString("MvcFlightContext") ?? throw new InvalidOperationException("Connection string 'MvcFlightContext' not found.")));
// }
// else
// {
//     builder.Services.AddDbContext<MvcFlightContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
//     builder.Services.AddStackExchangeRedisCache(options =>
//     {
//     options.Configuration = builder.Configuration["AZURE_REDIS_CONNECTIONSTRING"];
//     options.InstanceName = "SampleInstance";
//     });
// }

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add App Service logging
builder.Logging.AddAzureWebAppDiagnostics();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
