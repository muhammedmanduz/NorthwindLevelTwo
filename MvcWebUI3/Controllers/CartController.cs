using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI3.Helpers;
using MvcWebUI3.Models;

namespace MvcWebUI3.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;
        private ICartSessionHelper _cartSessionHelper;
        private IProductServices _productServices;


        public CartController(ICartService cartService, ICartSessionHelper cartSessionHelper, IProductServices productServices)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
            _productServices = productServices;
        }

        public IActionResult AddToCart(int productId)
        {
            //ürünü çek
            Product product = _productServices.GetById(productId);

            var cart = _cartSessionHelper.GetCart(key:"cart");

            _cartService.AddToCart(cart, product);

            _cartSessionHelper.SetCart(key:"cart",cart);

            TempData.Add("Message", product.ProductName + "sepete eklendi!");

            return RedirectToAction("Index", controllerName: "Product");
        }

        public IActionResult Index()
        {
            var model = new CartListViewModel
            {
                Cart=_cartSessionHelper.GetCart(key:"cart")
            };
            return View(model);
        }

        public ActionResult RemoveFromCart(int productId)
        {
            //ürünü çek
            Product product = _productServices.GetById(productId);
            var cart = _cartSessionHelper.GetCart(key: "cart");

            _cartService.RemoveFromCart(cart, productId);

            _cartSessionHelper.SetCart(key: "cart", cart);

            TempData.Add("Message", product.ProductName + "sepetten silindi!");


            return RedirectToAction("Index", controllerName: "Cart");
        }

        public IActionResult Complete()
        {
            var model = new ShippingDetailsViewModel
            {
                 ShippingDetail=new ShippingDetail()
            };
             return View(model);

        }

        [HttpPost]
        public IActionResult Complete(ShippingDetail shippingDetail)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message", "Siparişiniz başarıyla tamamlandı");
            _cartSessionHelper.Clear();
            return RedirectToAction("Index", controllerName: "Cart");
        }

    }
}
