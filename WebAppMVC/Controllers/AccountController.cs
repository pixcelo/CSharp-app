using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebAppMVC.Models;
using WebAppMVC.ViewModels;

public class AccountController : Controller
{
    private readonly BlogContext _context;

    public AccountController(BlogContext context)
    {
        _context = context;
    }

    // GET: Account/Login
    public IActionResult Login()
    {
        return View();
    }

    // POST: Account/Login
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // ユーザー認証ロジック（仮）
        var user = await _context.User
            .FirstOrDefaultAsync(u => u.Username == model.Username && u.Password == model.Password); // 本来はハッシュを比較

        if (user != null)
        {
            // 認証成功
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
                // その他のクレーム
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        // 認証失敗
        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        return View(model);
    }

    // POST: Account/Logout
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index", "Home");
    }
}
