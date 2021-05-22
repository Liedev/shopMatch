using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Winkellijst_ASP.Models;

namespace Winkellijst_ASP.Validators
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Naam)
                .NotEmpty()
                .NotNull()
                .WithMessage("Gelieve een naam in te vullen.");
            RuleFor(p => p.Prijs)
                .NotEmpty()
                .NotNull()
                .WithMessage("Gelieve een prijs in te vullen.");
            RuleFor(p => p.Beschrijving)
                .NotEmpty()
                .NotNull()
                .WithMessage("Gelieve een beschrijving in te voeren van het product");
            RuleFor(p => p.AfdelingId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Gelieve een afdeling te selecteren waar het product bij hoort.");
        }
    }
}
