using Microsoft.AspNetCore.Mvc;
using WebAppMvcStripe.Models;

namespace WebAppMvcStripe.Controllers
{
    public class CheckOutController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<ProductEntity>();

            products = new List<ProductEntity>
            {
                new ProductEntity
                {
                    Product = "Test Name",
                    Rate = 1500,
                    Quanity = 2,
                    ImagePath = "img/Image1.png"
                },
                new ProductEntity
                {
                    Product = "Test Name2",
                    Rate = 1000,
                    Quanity = 3,
                    ImagePath = "img/Image2.png"
                }
            };

            return View(products);
        }
    }
}
