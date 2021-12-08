using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //burada interint ettim. bunun bir methodinterception olduğunu söylemek için 
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType) //bana validator type'ı ver diyor
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//eğer kodu yazan kişi sana bir IValidator göndermediyse yani bir validatör yollamadıysa uyarı ver
            {                                                       //Yani gönderilen validatortype bir IValidator değilse  uyar onu.
                throw new System.Exception("Bu doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//Reflection:çalışma anında bir şeyleri çalıştırabilmemi sağlıyor. mesele newleme yapıcam bunu çalışma anında yapmamı sağlıyor. buradaki kod diyorki product validator'ın instencesinı oluştur örneğini
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//productvalidator'ın basetype'ını bul, onun geneceric argumanlarından 0.cısını yakala
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//metodun argümanlarını gez.eğer ki oradaki tip benim entity tipim yani product türünde ise onlarıaşşağıda valiadte et
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);//validationtool'u kullanarak validate et
            }
        }
    }
}
