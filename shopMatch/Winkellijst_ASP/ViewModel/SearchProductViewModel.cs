using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Winkellijst_ASP.Models;

namespace Winkellijst_ASP.ViewModel
{
    public class SearchProductViewModel
    {
        public string ZoekProducten { get; set; }
        public List<Product> Products { get; set; }
    }
}
