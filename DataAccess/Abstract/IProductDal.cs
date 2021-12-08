using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //Product'ın interface'ini oluşturdum. Yani burada ben Product tablosunun Dal'ını yazıyorum(Data Accsess Layer)
    //IproductDal= yani bu benim product ile ilgili veri tabanında yapacağım operasyonları içeren Interface. Operasyon(ekle çıkar sil güncelle listele getir vs.)
    public interface IProductDal:IEntityRepository<Product> //IentityRepositoy'i Product iin yapılandırdın dermek
    {
        List<ProductDetailDto> GetProductDetails();

    }
}
