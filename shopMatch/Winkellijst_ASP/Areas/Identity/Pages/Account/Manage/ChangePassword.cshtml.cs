using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Winkellijst_ASP.Areas.Identity.Data;

namespace Winkellijst_ASP.Areas.Identity.Pages.Account.Manage
{
    public class ChangePasswordModel : PageModel
    {
        private readonly UserManager<AppGebruiker> _userManager;
        private readonly SignInManager<AppGebruiker> _signInManager;
        private readonly ILogger<ChangePasswordModel> _logger;

        public ChangePasswordModel(
            UserManager<AppGebruiker> userManager,
            SignInManager<AppGebruiker> signInManager,
            ILogger<ChangePasswordModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Huidig wachtwoord")]
            public string OldPassword { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "Het {0} moet op zijn minst {2} en maximaal {1} karakers lang zijn.", MinimumLength = 4)]
            [DataType(DataType.Password)]
            [Display(Name = "Nieuw wachtwoord")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Bevestig nieuw wachtwoord")]
            [Compare("NewPassword", ErrorMessage = "Het nieuwe wachtwoord en het validatie wachtwoord stemmen niet overeen.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Het is niet gelukt om de gebruiker te laden met deze ID '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToPage("./SetPassword");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Het is niet gelukt om de gebruiker te laden met deze ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }

            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("De gebruiker heeft zijn wachtwoord succesvol aangepast.");
            StatusMessage = "Uw wactwoord is aangepast.";

            return RedirectToPage();
        }
    }
}
