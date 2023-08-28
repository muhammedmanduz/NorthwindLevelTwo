using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductServices
    {
        //EfProductDal  kullanacak
        private IProductDal _productDal;  //Dependency Injection
        public ProductManager(IProductDal productDal) // constructoru 
        {
            _productDal = productDal; //Dependency Injection
                                      //Biz ProductMAnagere newlwdiğimiz zaman ona bir tane IProductDal türünde ona instance verecegiz
        }

        public List<Product> GetAll()
        {
            return _productDal.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(p=>p.CategoryId == categoryId);
        }

        public Product GetById(int productId)
        {
          return _productDal.Get(filter:p=>p.ProductId==productId); 
        }
    }
}
