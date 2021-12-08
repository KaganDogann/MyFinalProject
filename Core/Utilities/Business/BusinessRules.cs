using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {   //Burada parametreyle gönderilen iş kurallarından başarısız olanı business'a haber ediyoruz
        public static IResult Run(params IResult[] logics)//params yazdığım zaman Run içerisinde istediğim kadar IResult verebiliyorum istediğim kadar.logics iş kuralı demek 
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
