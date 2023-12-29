using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Data.Repositories.BioskopRep;
using WebApp.Data.Repositories.BiskopRep;
using WebApp.Data.Repositories.FilmRep;
using WebApp.Data.Repositories.Producent;
using WebApp.Data.Repositories.ProducentRep;
using WebApp.Data.Services;
using WebApp.Data.UnitOfWork;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped < IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IGlumacRepository,GlumacRepository>();
builder.Services.AddScoped<IBioskopRepository, BioskopRepository>();
builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<IGlumacRepository, GlumacRepository>();

builder.Services.AddIdentity<ApplicatonUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});

builder.Services.AddControllersWithViews();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Filmovi}/{action=Index}/{id?}");



app.Run();



