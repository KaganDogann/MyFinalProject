using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    //Şimdi bu busines katmanı kime bağımlı veri erişime. ama veri eşiminde entity frame work olur başka bir şey olur o yüzden bağımlılığımızı mimimize ediyoruz bana I categorydal laazım.
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal; // bağımklılığımı consctor iinjektır ile yapıyorum.

        public CategoryManager(ICategoryDal categoryDal) // b uşu demek ben category manager oalrak veri eişim kaymanına bağlıyım ama biraz ayıf bağımlılığım var ben intercafe üüzerinden bağımlıtım. 
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            //iş kodları
            return new SuccessDataResult<List<Category>>( _categoryDal.GetAll());
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c=>c.CategoryId==categoryId));
        }
    }
}
