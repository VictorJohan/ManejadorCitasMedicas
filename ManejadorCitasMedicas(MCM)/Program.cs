using ManejadorCitasMedicas_MCM_.BLL;
using ManejadorCitasMedicas_MCM_.Data;
using ManejadorCitasMedicas_MCM_.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Serilog;

//Read Configuration from appSettings
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

//Initialize Logger
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();



var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddMudServices();
builder.Services.AddDbContext<SanVicentePaulDBContext>(options =>
               options.UseSqlServer(
                   config.GetConnectionString("DefaultConnection")));

//Servicios
builder.Services.AddTransient<ProvinciaBLL>();
builder.Services.AddTransient<CiudadBLL>();
builder.Services.AddTransient<DistritoBLL>();
builder.Services.AddTransient<SectorBLL>();

try
{
    Log.Information("Iniciando Aplicacion.");
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "The Application failed to start.");

}
finally
{
    Log.CloseAndFlush();
}



