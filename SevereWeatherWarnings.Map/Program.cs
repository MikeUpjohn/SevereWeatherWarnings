using SevereWeatherWarnings.Library.UseCases.Warnings;
using SevereWeatherWarnings.Library.UseCases.Warnings.Interfaces;
using SevereWeatherWarnings.Library.Utilities;
using SevereWeatherWarnings.Library.Utilities.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IGetWeatherWarnings, GetWeatherWarnings>();
builder.Services.AddScoped<IWebServiceRetriever, WebServiceRetriever>();
builder.Services.AddScoped<IMapWarnings, MapWarnings>();

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
