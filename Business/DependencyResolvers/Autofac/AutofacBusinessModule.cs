using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{   
    public class AutofacBusinessModule:Module //Sen bir modülsün. bunu burada implemente ederken. using Autofac diyeceğiz.
    {                                         //WebAPI deki startup kısımını buradan yapmamı sağlayacak
        protected override void Load(ContainerBuilder builder) //Uygulamayı çalıştırdığımızda bu kısım çalışacak.
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();//Burada ki durum şu birisi senden IProductService isterse ona ProductManager instance(örneği) ver dedik.
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            //builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()//bütün sınıflarım için aspect var mı bak diyoruz
                }).SingleInstance();

        }
    }
}
