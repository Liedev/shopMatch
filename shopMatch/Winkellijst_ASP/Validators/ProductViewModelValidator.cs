using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Winkellijst_ASP.ViewModel;

namespace Winkellijst_ASP.Validators
{
    public class ProductViewModelValidator: AbstractValidator<ProductViewModel>
    {
        public ProductViewModelValidator()
        {
            RuleFor(p => p.Product.Naam)
                .NotEmpty()
                .WithMessage("Gelieve een naam in te vullen.");
            RuleFor(p => p.Product.Prijs)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Gelieve een prijs in te vullen.");
            RuleFor(p => p.Product.Beschrijving)
                .NotEmpty()
                .WithMessage("Gelieve een beschrijving in te voeren van het product");
            RuleFor(p => p.Product.AfdelingId)
                .NotNull()
                .WithMessage("Gelieve een afdeling te selecteren waar het product bij hoort.");
        }
    }
}
