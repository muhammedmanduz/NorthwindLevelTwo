using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI3.Models;

namespace MvcWebUI3.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
       
    }
}
