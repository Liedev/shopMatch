using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winkellijst_ASP.Models
{
    public class Afdeling
    {
        public int AfdelingId { get; set; }
        public string Naam { get; set; }
        public int Volgorde { get; set; }
        public int WinkelId { get; set; }
        public Winkel Winkel { get; set; }
        public ICollection<Product> Producten{ get; set; }
    }
}
