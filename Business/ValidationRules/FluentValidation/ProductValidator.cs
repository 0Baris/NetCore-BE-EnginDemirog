using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        // FluentValidation -- Product için kurallar
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.CategoryID).NotEmpty();
            RuleFor(p => p.CategoryID).GreaterThan(0);
            
            // CategoryID 1 ise UnitPrice 10'dan büyük olmalı
            RuleFor(p=> p.UnitPrice).GreaterThanOrEqualTo(10).When(p=> p.CategoryID == 1);
            
            // Ürün a harfi ile başlamalı
            // kurallar hariç bir kural yazmak
            RuleFor(p=> p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}