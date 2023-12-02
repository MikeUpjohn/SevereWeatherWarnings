using SevereWeatherWarnings.Library.UseCases.Warnings;
using SevereWeatherWarnings.Library.UseCases.Warnings.GetAllWeatherWarnings;
using SevereWeatherWarnings.Library.UseCases.Warnings.GetAllWeatherWarnings.Interfaces;
using SevereWeatherWarnings.Library.UseCases.Warnings.GetSingleWarning;
using SevereWeatherWarnings.Library.UseCases.Warnings.GetSingleWarning.Interfaces;
using SevereWeatherWarnings.Library.UseCases.Warnings.Interfaces;
using SevereWeatherWarnings.Library.Utilities;
using SevereWeatherWarnings.Library.Utilities.Interfaces;
using SevereWeatherWarnings.Map.Presenters;
using SevereWeatherWarnings.Map.Presenters.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IGetWeatherWarnings, GetWeatherWarnings>();
builder.Services.AddScoped<IWebServiceRetriever, WebServiceRetriever>();
builder.Services.AddScoped<IMapWarnings, MapWarnings>();
builder.Services.AddScoped<IMapWarningDataPresenter, MapWarningDataPresenter>();
builder.Services.AddScoped<IWarnings, Warnings>();
builder.Services.AddScoped<IGetSingleWeatherWarning, GetSingleWeatherWarning>();
builder.Services.AddScoped<IMapWarningDetail, MapWarningDetail>();
builder.Services.AddScoped<IMapWarningDetailPresenter, MapWarningDetailPresenter>();

var app = builder.Build();

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
    pattern: "{controller=SevereWeatherMap}/{action=Index}/{id?}");

app.Run();
