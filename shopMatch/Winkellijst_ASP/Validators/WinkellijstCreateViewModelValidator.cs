using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Winkellijst_ASP.ViewModel;

namespace Winkellijst_ASP.Validators
{
    public class WinkellijstCreateViewModelValidator: AbstractValidator<WinkellijstCreateViewModel>
    {
        public WinkellijstCreateViewModelValidator()
        {
            RuleFor(wcvm => wcvm.Winkellijst.Naam)
                .NotEmpty()
                .WithMessage("Gelieve een naam in te vullen");
        }
    }
}
