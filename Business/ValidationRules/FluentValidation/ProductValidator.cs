using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product> //Product için validator. DTO için de yapablilirim bunu her şey için. 
    {
        public ProductValidator()//Hnagi nesne için validator yazacaksam bnun içine yazıyorum onu
        {

            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);//solid'ins harfinden dolayı ayrı ayrı veriyorum tek tek yazıyorum. araya bir gün where vs gelebilir. solid beni böyle yönlendiriyor.
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1); //kategori 1 deki ürünlerin fiyatı minumum 10 lira olmalı
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");//Olmayan bir kuralı kendimiz oluşrutuyoruz must ile.
            
        }

        private bool StartWithA(string arg) // arg benim parametrem yani productname. True döndürürsem kurala uygun, döndürmezsem kurala uygun değil.
        {
            return arg.StartsWith("A"); //A ile başlıyorsa true dönüyor, geçiyor üstteki satırı.
        }
    }
}
