using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI2.Models;

namespace MvcWebUI2.Controllers
{
    public class ProductController : Controller
    {
        //iş katmanına yani service erişmem lazım
        private IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        public IActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products=_productServices.GetAll()
            };

            return View(model: _productServices.GetAll());
        }
    }
}
