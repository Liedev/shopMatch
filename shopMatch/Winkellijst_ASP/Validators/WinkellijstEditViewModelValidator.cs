using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Winkellijst_ASP.ViewModel;

namespace Winkellijst_ASP.Validators
{
    public class WinkellijstEditViewModelValidator: AbstractValidator<WinkellijstEditViewModel>
    {
        public WinkellijstEditViewModelValidator()
        {
            RuleFor(wevm => wevm.Winkellijst.Naam)
               .NotEmpty()
               .WithMessage("Gelieve een naam in te vullen");
        }
    }
}
