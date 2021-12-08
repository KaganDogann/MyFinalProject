using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, String message):base(data,true,message)//public SuccessDataResult(T data, String message)=> bana bir tane data ver bir de mesaj ver. ama base'e de ki(DataResult) bu data, bu da messaje işlem sonucu ise default true.
        {
            
        }


        public SuccessDataResult(T data):base(data,true)//Mesaj olayına girmek istemiyor. T türünde data verip. base'e diyorki al  sana daat bu da true.
        {

        }

        public SuccessDataResult(string message):base(default,true,message)//Data default olarak döndürülüyor, sadece mesaj geçip gidiyor. gördüğün gibi base'e default dedim. yani bir şey döndürmek istemiyorum burada.
        {

        }

        public SuccessDataResult():base(default,true)// bi bok vermedim. base'e de direkt true diyorum.
        {

        }
    }
}
