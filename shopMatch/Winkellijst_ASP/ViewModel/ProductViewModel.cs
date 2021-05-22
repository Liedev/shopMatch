using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Winkellijst_ASP.Models;

namespace Winkellijst_ASP.ViewModel
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        public SelectList Afdeling { get; set; }
    }
}
