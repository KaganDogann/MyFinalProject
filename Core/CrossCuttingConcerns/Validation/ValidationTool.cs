using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity) //IValidator validator, bizim productValidator buraya gelecek. object hepsinin base'i buraya her şe gelebilir.
        {
            var context = new ValidationContext<object>(entity); //bir doğrulama context'i oluştur
            
            var result = validator.Validate(context); //context buradaki entity

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
