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
    public class CategoryManager : ICategoryService
    {
        //Alt katmandakı Veri erişim katmana ulasmak için bır classa ihtiyac var
        //Bir katman diğer katmana interface i üzerinden iletişim kurar

        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal )
        {
            _categoryDal = categoryDal;//EntityFramework tarfındakı kodlar
            
        }
        public List<Category> GetAll()
        {
            return _categoryDal.GetList(); //Tümünü listele
        }
    }
}
