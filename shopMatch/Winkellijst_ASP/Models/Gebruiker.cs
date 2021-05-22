using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Winkellijst_ASP.Areas.Identity.Data;

namespace Winkellijst_ASP.Models
{
    public class Gebruiker
    {
        public int GebruikerId { get; set; }
        [ForeignKey("AppGebruiker")]
        public string AppGebruikerId { get; set; }
        public AppGebruiker AppGebruiker { get;}
    }
}
