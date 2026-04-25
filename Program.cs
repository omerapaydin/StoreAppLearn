using Microsoft.EntityFrameworkCore;
using StoreAppLearn.Data.Abstract;
using StoreAppLearn.Data.Concrete;
using StoreAppLearn.Models;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddDbContext<StoreDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("CustomConnection")); 
});

builder.Services.AddScoped<IStoreRepository, EfStoreRepository>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<Cart>();

var app = builder.Build();
app.UseStaticFiles();
app.UseSession();


app.MapControllerRoute("products_in_category" , "products/{category?}", new { controller = "Home", action = "Index" });

app.MapControllerRoute("product_details" , "{name}", new { controller = "Home", action = "Details" });



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); 

app.MapRazorPages();

app.Run();
