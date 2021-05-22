using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Winkellijst_ASP.Models;

namespace Winkellijst_ASP.Areas.Identity.Data
{
    public class AppGebruiker: IdentityUser
    {
        [PersonalData]
        public Gebruiker Gebruiker { get; set; }
    }
}
