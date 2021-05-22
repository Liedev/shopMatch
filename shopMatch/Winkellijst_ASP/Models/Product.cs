using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winkellijst_ASP.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Naam { get; set; }
        public decimal Prijs { get; set; }
        public string Beschrijving { get; set; }
        public int AfdelingId { get; set; }
        public Afdeling Afdeling { get; set; }
        public ICollection<WinkelLijstProduct> WinkelLijstProducts { get; set; }
    }
}
