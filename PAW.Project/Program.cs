using Microsoft.EntityFrameworkCore;
using PAW.Data.Models;
using PAW.Repository.Repositories;
using PAW.Repository.Interfaces;
using PAW.Business;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure DbContext
builder.Services.AddDbContext<CaseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
//builder.Services.AddScoped<IRepositoryBase<OfficeRequest>, RepositoryBase<OfficeRequest>>();
builder.Services.AddScoped<IOfficeRequestRepository, OfficeRequestRepository>();
builder.Services.AddScoped<IOfficeRequestDetailsRepository, OfficeRequestDetailsRepository>();

// Register business layer
builder.Services.AddScoped<OfficeRequestBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Requests}/{action=Index}/{id?}");

app.Run();