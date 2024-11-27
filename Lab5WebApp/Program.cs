using Ninject;
using Ninject.Web.Mvc;
using Lab5WebApp.Util;
using System.Web.Mvc;
using Microsoft.EntityFrameworkCore;
using Interfaces.Services;
using BLL.Services;
using Interfaces.Repository;
using DAL.Repository;
using DAL;
using DAL.MongoRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Configuration.AddJsonFile("appsettings.json");
//builder.Services.AddDbContext<MongoContext>(options =>
//{
//    /*options.UseNpgsql(builder.Configuration.GetConnectionString("dbPizzaDelivery"))*/;
//});

//builder.Services.AddScoped<MongoContext>(s =>
//{
//    return new MongoContext(builder.Configuration.GetConnectionString("PDMongo"));
//});
builder.Services.AddScoped<IDbRepos, DbReposMongo>(s =>
{
    return new DbReposMongo(builder.Configuration.GetConnectionString("PDMongo"));
});

builder.Services.AddScoped<IOrderLineService, OrderLinesService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IUserService, UserService>();


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
    pattern: "{controller=Home}/{action=Index}/{id?}");
//var kernel = new StandardKernel(new NinjectRegistrations());
//DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
app.Run();
