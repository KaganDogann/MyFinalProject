using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)] //Classlara veya methodlara ekleyebilirsin bu attribute'ü, birden fazla ekleyebilirsin. ve inherint edilen bir yerde kullanılabilir.
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor//IInterceptor using Castle.DynamicProxy; buradan geliyor.Autofac'in interceptor'ını kullanıyorum.
    {
        public int Priority { get; set; }//öncelik demek burası. hangi attribute önce çalışsın, log/validation/ vs vs

        public virtual void Intercept(IInvocation invocation) //ne yapacağını burada doldurucaz
        {

        }
    }
}
