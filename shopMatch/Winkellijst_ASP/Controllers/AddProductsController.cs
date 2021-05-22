using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Winkellijst_ASP.Areas.Identity.Data;
using Winkellijst_ASP.Data;
using Winkellijst_ASP.Models;
using Winkellijst_ASP.ViewModel;

namespace Winkellijst_ASP.Controllers
{
    [Authorize]
    public class AddProductsController : Controller
    {
        private readonly GebruikerContext _context;
        private readonly UserManager<AppGebruiker> _userManager;

        public AddProductsController(GebruikerContext context, UserManager<AppGebruiker> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private async Task<IActionResult> Main(int id, string q = "")
        {
            WinkelLijst list = await _context.WinkelLijsten.Where(w => w.WinkelLijstId == id).FirstOrDefaultAsync();

            if (list != null)
            {
                var userId = _userManager.GetUserId(User);
                Gebruiker gebruiker = await _context.Gebruikers.FirstOrDefaultAsync(x => x.AppGebruikerId == userId);

                if (gebruiker.GebruikerId != list.GebruikerId)
                {
                    return Forbid();
                }

                var query = _context.Producten.Include(p => p.Afdeling).AsQueryable();

                if (!string.IsNullOrWhiteSpace(q))
                {
                    query = query.Where(p => p.Naam.Contains(q) || p.Afdeling.Naam.Contains(q));
                }

                return View("Index", new AddProductsViewModel
                {
                    List = list,
                    Products = await query.ToListAsync(),
                    WinkelLijstProduct = new WinkelLijstProduct()
                });
            }

            return NotFound();
        }

        // GET: AddProducts/5
        public async Task<IActionResult> Index(int id)
        {
            return await Main(id);
        }

        // GET: AddProducts/5/Search?q=
        public async Task<IActionResult> Search(int id, string q)
        {
            return await Main(id, q);
        }

        // POST: AddProducts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WinkelLijstProductId,Aantal,WinkelLijstId,ProductId")] WinkelLijstProduct winkelLijstProduct)
        {
            if (ModelState.IsValid)
            {
                var winkellijstProduct1 = await _context.WinkelLijstProduct
                    .FirstOrDefaultAsync(wp => wp.ProductId == winkelLijstProduct.ProductId && wp.WinkelLijstId == winkelLijstProduct.WinkelLijstId);

                if (winkellijstProduct1 != null)
                {
                    winkellijstProduct1.Aantal += winkelLijstProduct.Aantal;
                    _context.Update(winkellijstProduct1);
                }
                else
                {
                    _context.Add(winkelLijstProduct);
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "WinkelLijst", new { id = winkelLijstProduct.WinkelLijstId });
        }
    }
}
