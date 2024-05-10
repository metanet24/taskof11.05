using Microsoft.EntityFrameworkCore;
using slider.Data;
using slider.Services;
using slider.Services.Interface;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("default")));


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoriyService, CategoryService>();
builder.Services.AddScoped<IExpertService, ExpertService>();
builder.Services.AddScoped<IExpertSliderService, ExpertSliderService>();
builder.Services.AddScoped<IInstagramService, InstagramService>();


var app = builder.Build();


app.UseStaticFiles();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
