using Microsoft.EntityFrameworkCore;
using R52_M8_Class_01_Work_01.Models;
using R52_M8_Class_01_Work_01.Repositories;
using R52_M8_Class_01_Work_01.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();
