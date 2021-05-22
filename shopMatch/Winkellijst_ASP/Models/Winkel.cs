using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Winkellijst_ASP.Models
{
    public class Winkel
    {
        public int WinkelId { get; set; }
        
        public string Winkelnaam  { get; set; }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public string Stad { get; set; }
        public ICollection<Afdeling> Afdelingen{ get; set; }

    }
}
