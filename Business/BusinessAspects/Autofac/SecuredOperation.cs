using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac//03.16
{//JWT
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)//ProductManager!ımın içinde ki roller buraya geliyor
        {
            _roles = roles.Split(',');//roles.Split=> senin belirttiğin verdiğğin şeyi dizi haline getiriyor. viegül gördükçe onu array'e atıyor
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();//ServiceTool bizim injection altyapımızı aynen okuyacak bir araç olacak.

        }
        // valla anlamadım hocam ya bende inan anlamadım 2 gündür videoları izliyorum aynısını yapıyprum yine aynı
        // grupta belki bilen birisi çıkar daha önceden bu sorunu atanlar olmuştu diye hatırlıyorum. evet baktımonlarada 8 ane mesaj vardı hiçbirisinede çözüm gelmemişti
        // bilemedim yine de bi sor tamamdır hocam çok teşekkürler rica ederim kolay gelsin teşekkürler sana da :)
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
