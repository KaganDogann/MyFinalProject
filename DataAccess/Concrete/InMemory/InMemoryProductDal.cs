using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    //DataAccses içinde veriye erişim teknikleri vardır. Birden fazla teknik vardır.Burada sanki bellekte veri tabanı varmış gibi fake bir sistemle çalışıyorum unutma.
    //InMemoryProductDal= bellek üzerinde ürünle ilgili veri erişim kodlarını yazılacğı yer anlamında.
    //Mesela Concrete klasörü içerisinde EntityFramework klasörüm var. orada da veriye erişim için başka bir teknik kullanacağım.
    //Bellekte sanki datam varmışta onunla çalışacağım gibi davranıyorum.
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //Bunu class'ın içinde metotların dışında tanımladığım için Global olarak geçiyor.Sadece bir değişken oluşturdum.
        public InMemoryProductDal() //Constructor uygulama çalışştığı an  new lendiği an da burası çalışacak. Bende alta kendim sahte bir veri tabanı oluşturacağım.
                                    //Yani new lendiği an da burada alttaki ürünleri oluşturacak.
        {
            _products = new List<Product> { 
                new Product {ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product {ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3}, //Bunların hepsi birer farklı referans numaralarına sahip.
                new Product {ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},// Yani altta silme veya güncelleme işlemi yaparken sorun yaşayacağım.
                new Product {ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},//Direkt bunların referansına erişmem gerekli.
                new Product {ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1},

            };
        }
        public void Add(Product product)
        {
            _products.Add(product); //Business dan bana gönderilen ürünü alıyorum veri tabanına ekliyorum.
            
        }

        public void Delete(Product product)//Burada bana Product tablosundan bir product gelecek.
        {                                  // gelen product ın Id sini kullaranak yukarıda eşleşen Id yi bulup onun referansını yakalayacağım
            //Product productToDelete = null;
            //foreach (var p in _products)//Listemin tüm elemanlarını gezmek için bir döngü oluşturdum. 
            //{
            //    if (p.ProductId == product.ProductId)//Bir koşul belirttim. dedim ki benim product'ımın Id si ile gönderdiğim product Id si aynı ise 
            //    {
            //        productToDelete = p; //productToDelete' e eşitliği sağlayan ürünümün referansını eşitle.
            //    }

            //}
            //Aşağıadki kodda LINQ kullanıldı!
           Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);//SingleOrDefault=tek bir eleman bulmaya yarar, _products ı tek tek dolaşmaya yarar.
            //p=>Lambda anlamına gelir o yazdığım p, foreachte ki p ile aynı(takma isim). burada yukarıda yazdığım forech'in LINQ kullanarak çok daha basit ve sade halini yazdım.

            _products.Remove(productToDelete);//Silme işlemini gerçekleştirdim.
        }

        public List<Product> GetAll()//Veri tabanında ki datayı business'a vermem lazım. 
        {
            return _products; //Tüm ürünleri geri döndürdüm. Listeyi yani
            
        }

        public void Update(Product product)
        {   
            //Gönderdiğim ürün Id'sine sahip olan Listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
           
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //Where koşulu içinde ki şarta uyan bütün elemanları yeni bir liste haline getirir ve onu döndürür.
            return _products.Where(p => p.CategoryId == categoryId).ToList(); 

        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
