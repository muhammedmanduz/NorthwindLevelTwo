using Entities.Concrete;
using System.Collections.Generic;

namespace MvcWebUI3.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; set; }
        public int CurrentCategory { get;  set; }
    }
}
