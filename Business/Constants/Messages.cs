using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages//static newlemiyorum. direkt Messages. diyorum. Temel mesajlarımız bunun içinde.
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";//public'ler PascalCase yazılır
        public static string MaintenanceTime="sistem bakımda";
        public static string ProductListed="ürünler listelendi";
        public static string ProductCountOfCategoryError="Kategorideki ürün sayısı 10 dan fazla";
        public static string ProductNameAlreadyExists="Aynı isimden ürün var";
        public static string CategoryLimitExceded="Kategori limiti aşıldığı için yeni ürün eklenemiyor.";
        public static string AuthorizationDenied = "Yetkin yok";
    }
}
