using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Winkellijst_ASP.Models;

namespace Winkellijst_ASP.ViewModel
{
    public class AddProductsViewModel
    {
        public string q { get; set; }
        public List<Product> Products { get; set; }
        public WinkelLijst List { get; set; }
        public WinkelLijstProduct WinkelLijstProduct { get; set; }
    }
}
