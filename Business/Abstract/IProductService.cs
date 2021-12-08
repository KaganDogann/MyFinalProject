using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    // iş katmanında kullnacağım servis operayonları
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll(); //IDataResult hem işlem sonucunu hem mesajı hemde döndüreceği şeyi içeren(listofproduct) bunları döndüren bir yapı görevi görecek.
        IDataResult<List<Product>> GetAllByCategoryId(int id); //By = ile
        IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max);//Şu fiyat aralığında olan ürünleri getir.

        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IResult Add(Product product); //Void silinde diyorum ki sen bi IResult döndür. void olan yerde bunu dedim.

        IDataResult<Product> GetById(int productId);
        IResult Update(Product product);
        IResult AddTransactionalTest(Product product);

    }
}
