using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogContext _context;

        public BlogController(BlogContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var blogs = _context.Blog.ToList();
            return View(blogs);
        }
    }
}
