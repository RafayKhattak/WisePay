// Import necessary namespaces
using Microsoft.EntityFrameworkCore;
using ViseVault.Models;

// Create a new instance of WebApplication builder
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Dependency Injection (DI): Add Entity Framework DbContext to the service container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

// Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBMAY9C3t2VVhhQlFac1pJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxRdkNjWn9edHNRRmZYWEM=");

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline.
// If not in development environment, use exception handler middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Enable serving of static files
app.UseStaticFiles();

// Enable routing
app.UseRouting();

// Enable authorization
app.UseAuthorization();

// Map default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

// Run the application
app.Run();
