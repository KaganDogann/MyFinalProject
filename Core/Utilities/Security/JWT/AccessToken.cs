using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class  AccessToken
    {   //AccesToken nesnelerim
        public string Token { get; set; }//girş yapan kullanıcıya vereceğim token 
        public DateTime Expiration { get; set; }// kullanıcının token süresinin gerçiliği.
    }
}
