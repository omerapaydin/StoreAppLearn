using Microsoft.EntityFrameworkCore;
using StoreAppLearn.Data.Abstract;
using StoreAppLearn.Data.Concrete;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("CustomConnection")); 
});

builder.Services.AddScoped<IStoreRepository, EfStoreRepository>();




var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); 

app.Run();
