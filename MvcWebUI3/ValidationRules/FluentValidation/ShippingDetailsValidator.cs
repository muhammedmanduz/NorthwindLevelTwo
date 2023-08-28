using FluentValidation;
using MvcWebUI3.Models;
using System;

namespace MvcWebUI3.ValidationRules.FluentValidation
{
    public class ShippingDetailsValidator:AbstractValidator<ShippingDetail>
    {
        public ShippingDetailsValidator()
        {
            RuleFor(s => s.FirstName).NotEmpty().WithMessage("Adı gerekli!");
            RuleFor(s => s.FirstName).MinimumLength(3);
            RuleFor(s => s.LastName).NotEmpty();
            RuleFor(s => s.Address).NotEmpty();
            RuleFor(s => s.City).NotEmpty().When(s=>s.Age<18);
            //must: meli malı kendi kuralını koy
            RuleFor(s => s.FirstName).Must(StartWithA);
        }

        private bool StartWithA(string arg)//arg :gonderilen deger =FirtName demek
        {
           return arg.StartsWith("A");
        }
    }
}
