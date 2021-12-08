using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result //InHeritance. Constructor isteyecek. 
    {
        public SuccessResult(string message) : base(true, message) // Bu SuccessResult sadece message alsın. base=Result. Base'e bir şey göndermek için kulanılır. biz burada true dedik çünkü işlem zaten başarılı aynı zamanda orada message da gönderiyorum.
        {


        }

        public SuccessResult():base(true) // burasıda sadece mesaj vermek istemiyor olabilirim. burada da diyorum ki base in tek parametreleli olanını çalıştır. success i verdi. yani arkada yaptığım return new SuccessResult () şeklinde kullanabildim. bi parametre yollamadım. paranteziz içi boş
        {


        }
    }
}
