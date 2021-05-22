using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Winkellijst_ASP.Models;

namespace Winkellijst_ASP.Validators
{
    public class WinkelLijstValidator: AbstractValidator<WinkelLijst>
    {
        public WinkelLijstValidator()
        {
            RuleFor(w => w.Naam)
                .NotEmpty()
                .NotNull()
                .WithMessage("Gelieve een naam in te vullen");
        }
    }
}
