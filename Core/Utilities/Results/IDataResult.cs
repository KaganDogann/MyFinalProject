using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>: IResult// IDataResult<T>=> Hangi tipi döndüreceğini bana söyle // Mesajla işlem sonucu IResult içerior zaten o yüzden implemetasyon yapıyorum.
    {
        T Data { get; } //Burada da datam olacak. bu data da şu an ürünüm veya ürünler olacak. hepsi olur. Sonuçta tipim T
    }
}
