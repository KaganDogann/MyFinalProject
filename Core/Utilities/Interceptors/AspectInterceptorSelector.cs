using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>//git classın attribute'lerini oku
                (true).ToList();//bunlar listeye koy
            var methodAttributes = type.GetMethod(method.Name)//ilgili metodun attributelerini oku, loglama vs vs 
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);

            //classAttributes.Add

            return classAttributes.OrderBy(x => x.Priority).ToArray();// bu attributeleri çalışma sırasına göre sırala
        }
    }
}
