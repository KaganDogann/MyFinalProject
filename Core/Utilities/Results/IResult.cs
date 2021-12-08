using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç. Voidleri bu IResult yapısıyla süslüycez.
    public interface IResult
    {
        bool Success { get; } // get demek sadece okunabilir demek. 
        string Message { get; }
    }
}
