using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RegistroOcupacion.Data;
using Microsoft.EntityFrameworkCore;
using RegistroOcupacion.BLL;
using RegistroOcupacion.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();



builder.Services.AddDbContext<Contexto>(options =>

                options.UseSqlite(builder.Configuration.GetConnectionString("ConStr"))

                );
builder.Services.AddTransient<OcupacionesBLL>();


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
