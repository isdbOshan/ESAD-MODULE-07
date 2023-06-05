using Microsoft.EntityFrameworkCore;
using R52_M8_Class_03_Work_01.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ContactDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();
