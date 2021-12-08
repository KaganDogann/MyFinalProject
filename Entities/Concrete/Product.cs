
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    //public yapmamız bu class'a diğer katmanlarda ulaşsın demek. benim üç katmanımda entities' i kullanacak.
    //  Veri tabanımda ki isimiyle aynı şekilde yazıyorum. Şu an gerçek veri tabanıyla çalışmıyorum yani sadece bir simulasyon hazırlıyorum.
    public class Product:IEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
