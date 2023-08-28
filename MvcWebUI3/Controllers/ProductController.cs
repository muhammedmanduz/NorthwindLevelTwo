using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using MvcWebUI3.Models;

namespace MvcWebUI3.Controllers
{
    public class ProductController:Controller
    {
        private IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public IActionResult Index(int category)
        {
            var model = new ProductListViewModel
            {
                Products = category>0?_productServices.GetByCategory(category):_productServices.GetAll()
            };
            return View(model);  

        }
    }
}
