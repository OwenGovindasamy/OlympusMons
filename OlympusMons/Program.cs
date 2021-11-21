using Microsoft.EntityFrameworkCore;
using OlympusMons.Interfaces;
using OlympusMons.Logic;
using OlympusMons.Models;
using Microsoft.AspNetCore.Identity;
using OlympusMons.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Ideally OlympusMonsContext... should be in its own Identity Framework DB
builder.Services.AddDbContext<OlympusMonsContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<OlympusMonsContext>();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
// Adds services for Razor Pages to the app
builder.Services.AddRazorPages();
// Add services to the container.
builder.Services.AddControllersWithViews();
// Injecting interfaces
builder.Services.AddScoped<IDbModule, DbModule>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
// Adds endpoints for Razor Pages
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


//FORGET IDENTITY FOR NOW....