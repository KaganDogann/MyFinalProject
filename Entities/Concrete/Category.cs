using Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{   

    //Çıplak class kalmasın, bir 
    // Şimdi burada concrete klasöründe ki classlarım bir veri tabanı tablosu. bunuişaretlemek için içi boş bir Interface oluşturdum. Yani işaretleme yaptım.Kendi yorumum.
    public class Category:IEntity 
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
