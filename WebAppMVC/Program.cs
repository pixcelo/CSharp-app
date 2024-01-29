using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppMVC.Models;
using WebAppMVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<WeatherService>();
builder.Services.AddScoped<IPasswordHasher<ApplicationUser>, PasswordHasher<ApplicationUser>>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
    options.SignIn.RequireConfirmedAccount = false) // �O�����O�C���ł̓A�J�E���g�m�F�����߂Ȃ�
    .AddEntityFrameworkStores<BlogContext>()
    .AddDefaultTokenProviders();

// �F�؃T�[�r�X��ǉ�
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.LogoutPath = "/Account/Logout";
        })
        .AddGoogle(googleOptions =>
        {
            // Google API Console�Ŏ擾�����N���C�A���gID�ƃV�[�N���b�g���g�p
            googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
            googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
            googleOptions.CallbackPath = new PathString("/signin-google");
        });

// DbContext
var connectionString = builder.Configuration.GetConnectionString("BlogContext");
builder.Services.AddDbContext<BlogContext>(options =>
    options.UseSqlServer(connectionString));

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

// �F�؃T�[�r�X
app.UseAuthentication();
app.UseAuthorization();

app.Run();
