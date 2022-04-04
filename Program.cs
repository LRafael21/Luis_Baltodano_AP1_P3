using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Luis_Baltodano_AP1_P3.Data;
using Luis_Baltodano_AP1_P3.DAL;
using Luis_Baltodano_AP1_P3.BLL;
using Luis_Baltodano_AP1_P3.BLLServicios;
using Luis_Baltodano_AP1_P3.BLLContratos;
using Luis_Baltodano_AP1_P3.Entidades;
using Microsoft.EntityFrameworkCore;
using Blazored.Toast;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddBlazoredToast();

builder.Services.AddDbContext<Contexto>(options => options.UseSqlite(builder.Configuration.GetConnectionString("ConStr"))
);

//Inyectar BLL
builder.Services.AddTransient<ClientesBLL>();
builder.Services.AddTransient<ServiciosBLL>();
builder.Services.AddTransient<ContratosBLL>();

builder.Services.AddTransient<Clientes>();

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
