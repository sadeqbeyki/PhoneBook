using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhoneBook.EndPoints.Models.AAA;
using PhoneBook.Infrastructure.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("PhoneBookDB");
ConfigureServices.Configure(builder.Services, connectionString);

builder.Services.AddDbContext<UserDbContext>(c =>
    c.UseSqlServer(builder.Configuration.GetConnectionString("aaa")));

builder.Services.AddScoped<IPasswordValidator<AppUser>, CPBPasswordValidator>();
builder.Services.AddScoped<IUserValidator<AppUser>, PBUserValidator>();

builder.Services.AddIdentity<AppUser, PBIdentityRole>(c =>
{
    c.User.RequireUniqueEmail = true;
    //c.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnmPOIUYTREWQLKJHGFDSAMNBVCXZ";
    c.Password.RequireDigit = false;
    c.Password.RequiredLength = 6;
    c.Password.RequireNonAlphanumeric = false;
    c.Password.RequireUppercase = false;
    c.Password.RequiredUniqueChars = 1;
    c.Password.RequireLowercase = false;
}).AddEntityFrameworkStores<UserDbContext>();



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

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
