using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebAppMVC.Models;
using WebAppMVC.ViewModels;

public class AccountController : Controller
{
    private readonly BlogContext _context;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(
        BlogContext context, 
        IPasswordHasher<User> passwordHasher, 
        SignInManager<IdentityUser> signInManager)
    {
        _context = context;
        _passwordHasher = passwordHasher;
        _signInManager = signInManager;
    }

    // GET: Account/Register
    public IActionResult Register()
    {
        return View();
    }

    // POST: Account/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {            
            ModelState.AddModelError(string.Empty, "登録に失敗しました。入力内容を確認してください。");
            return View(model);
        }

        // データベースに同じメールアドレスがあるか確認
        if (_context.User.Any(u => u.Email == model.Email))
        {
            ModelState.AddModelError("Email", "An account with this email already exists.");
            return View(model);
        }

        var user = new User { Email = model.Email, Username = model.Username };
        user.Password = _passwordHasher.HashPassword(user, model.Password);
        _context.User.Add(user);
        await _context.SaveChangesAsync();
        // 登録後の処理（ログイン処理など）
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        return RedirectToAction("Index", "Home");
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

        // ユーザー認証ロジック
        var user = await _context.User
            .SingleOrDefaultAsync(u => u.Email == model.Email);

        if (user != null && 
            _passwordHasher.VerifyHashedPassword(user, user.Password, model.Password) == PasswordVerificationResult.Success)
        {
            // 認証成功
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
                // その他のクレーム
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            // ログイン状態の保存
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(14) // 例: 14日間有効
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                authProperties);

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

    public IActionResult GoogleLogin()
    {
        var redirectUrl = Url.Action("GoogleResponse", "Account");
        var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
        return new ChallengeResult("Google", properties);
    }

    public async Task<IActionResult> GoogleResponse()
    {
        var info = await _signInManager.GetExternalLoginInfoAsync();
        if (info == null)
        {
            return RedirectToAction(nameof(Login));
        }

        var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }
        else
        {
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var user = new User { Username = email, Email = email };
            var identityResult = await _userManager.CreateAsync(user);
            if (identityResult.Succeeded)
            {
                identityResult = await _userManager.AddLoginAsync(user, info);
                if (identityResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction(nameof(Register));
        }
    }
}
