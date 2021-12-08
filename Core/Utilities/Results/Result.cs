using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
       

        public Result(bool success, string message):this(success) //this demek bu class demek, class ın kendisi demek, Result demek yani// result ın consctorına success i yolla o da çalışsın. //Burada iki parametre gönderilirse iki constructor'da çalışmış olacak
        {
            Message = message; //Burada set etme işlemi yaptım. parametre olarak gelen message'yi Get olan Message'ye set ettim
           
        }

        public Result(bool success) //Overloaading işlemini yaptım. 
        {
            
            Success = success;
        }

        public bool Success { get; } //get haline getirdim. //GET READONLY'DİR READONLY'LER CONSTRUCTOR' DA SET EDİLEBİLİR.

        public string Message { get; }
    }
}
