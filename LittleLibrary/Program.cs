using LittleLibrary.Models;
using LittleLibrary.Models.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<DataService>();

var connString = builder.Configuration
    .GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LittleLibraryContext>(
    o => o.UseSqlServer(connString));

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(o => o.MapControllers());
app.UseStaticFiles();

app.Run();
