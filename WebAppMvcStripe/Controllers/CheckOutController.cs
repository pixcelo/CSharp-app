using Microsoft.AspNetCore.Mvc;
using WebAppMvcStripe.Models;
using Stripe.Checkout;

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

        public IActionResult ChgeckOut()
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

            var url = "http://localhost:5239/";

            var options = new Stripe.Checkout.SessionCreateOptions
            {
                SuccessUrl = url + "CheckOut/OrderConfirmation",
                CancelUrl = url + "CheckOut/Login",
                LineItems = new List<SessionLineItemOptions>(),                
                Mode = "payment",
            };

            foreach (var item in products)
            {
                var sessionListItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Rate * item.Quanity),
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Product.ToString(),
                        }
                    },
                    Quantity = item.Quanity
                };
                options.LineItems.Add(sessionListItem);
            }

            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);

            return new StatusCodeResult(303);
        }
    }
}
