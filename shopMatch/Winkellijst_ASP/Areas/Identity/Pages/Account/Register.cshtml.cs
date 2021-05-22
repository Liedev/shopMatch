using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Winkellijst_ASP.Data;
using Winkellijst_ASP.Areas.Identity.Data;
using Winkellijst_ASP.Models;

namespace Winkellijst_ASP.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AppGebruiker> _signInManager;
        private readonly UserManager<AppGebruiker> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly GebruikerContext _context;

        public RegisterModel(
            UserManager<AppGebruiker> userManager,
            SignInManager<AppGebruiker> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            GebruikerContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.EmailAddress)]
            [EmailAddress]
            [Display(Name = "E-mail")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "Het {0} moet op z'n minst {2} en maximum {1} karakters lang zijn.", MinimumLength = 4)]
            [DataType(DataType.Password)]
            [Display(Name = "Wachtwoord")]
            public string Wachtwoord { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Bevestig wachtwoord")]
            [Compare("Wachtwoord", ErrorMessage = "Het wachtwoord en het controle wachtwoord zijn niet hetzelfde.")]
            public string BevestigWachtwoord { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (!Input.Email.Contains("."))
            {
                ModelState.AddModelError(string.Empty, "E-mailadres is onvolledig.");
            }
            if (ModelState.IsValid)
            {
                var user = new AppGebruiker 
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    Gebruiker = new Gebruiker()
                };
                var result = await _userManager.CreateAsync(user, Input.Wachtwoord);
                user.Gebruiker.AppGebruikerId = user.Id;
                await _context.SaveChangesAsync();
                if (result.Succeeded)
                {
                    _logger.LogInformation("De gebruiker heeft een nieuw account met een wachtwoord aangemaakt.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);
                    

                    await _emailSender.SendEmailAsync(Input.Email, "Bevestig je e-mail",
                        $"Gelieve je account te bevestigen door <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>hier te klikken</a>.");
                    

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Winkellijst");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Registratie is mislukt. Probeer het later nog eens.");
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
