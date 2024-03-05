using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GcpApp.Models;

namespace GcpApp.Controllers;

public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (IsValidLogin(email, password)) 
            {                
                return RedirectToAction("Index", "Dashboard");
            }
            
            ViewBag.ErrorMessage = "Invalid email or password";
            return View("Index"); 
        }
        
        private bool IsValidLogin(string email, string password)
        {            
            return email == "admin" && password == "password"; 
        }
    }
