using Microsoft.EntityFrameworkCore;
using OlympusMons.Interfaces;
using OlympusMons.Logic;
using OlympusMons.Models;
using Microsoft.AspNetCore.Identity;
using OlympusMons.Data;
using AutoMapper;
using OlympusMons.Mappings;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

// Ideally OlympusMonsContext... should be in its own Identity Framework DB
builder.Services.AddDbContext<OlympusMonsContext>(options => options.UseSqlServer(connectionString));
//configure identity framework and allow weaker passwords
builder.Services.AddDefaultIdentity<IdentityUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false; 
    options.Password.RequireNonAlphanumeric = false; }).AddEntityFrameworkStores<OlympusMonsContext>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
// AutoMapper config
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
