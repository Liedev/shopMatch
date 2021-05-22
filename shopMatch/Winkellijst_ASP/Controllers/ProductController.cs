using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Winkellijst_ASP.Data;
using Winkellijst_ASP.Models;
using Winkellijst_ASP.ViewModel;

namespace Winkellijst_ASP.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly GebruikerContext _context;

        public ProductController(GebruikerContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            SearchProductViewModel searchProductViewModel = new SearchProductViewModel();
            searchProductViewModel.Products = await _context.Producten.Include(p => p.Afdeling).ToListAsync();
            return View(searchProductViewModel);
        }

        //GET: Searchfilter

        public async Task<IActionResult> Search(SearchProductViewModel searchProductViewModel)
        {
            if (!string.IsNullOrEmpty(searchProductViewModel.ZoekProducten))
            {
                searchProductViewModel.Products = await _context.Producten.Include(p => p.Afdeling)
                    .Where(c => c.Naam.Contains(searchProductViewModel.ZoekProducten)).ToListAsync();
            }
            else
            {
                searchProductViewModel.Products = await _context.Producten.Include(p => p.Afdeling).ToListAsync();
            }
            return View("Index", searchProductViewModel);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Product = new Product();
            productViewModel.Afdeling = new SelectList(_context.Afdelingen, "AfdelingId", "Naam");
            return View(productViewModel);
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            Product productNaam = await _context.Producten.FirstOrDefaultAsync(x => x.Naam == productViewModel.Product.Naam);
            if (productNaam != null)
            {
                ModelState.AddModelError(string.Empty, "Deze productnaam bestaat al");
            }
            else if (ModelState.IsValid)
            {
                _context.Add(productViewModel.Product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            productViewModel.Afdeling = new SelectList(_context.Afdelingen, "AfdelingId", "Naam", productViewModel.Product.AfdelingId);
            return View(productViewModel);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Producten.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Product = product;
            productViewModel.Afdeling = new SelectList(_context.Afdelingen, "AfdelingId", "Naam", product.AfdelingId);
            return View(productViewModel);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Product.ProductId)
            {
                return NotFound();
            }
            Product productNaam = await _context.Producten.Where(x => x.Naam == productViewModel.Product.Naam && x.ProductId != id).FirstOrDefaultAsync();
            if (productNaam != null)
            {
                ModelState.AddModelError(string.Empty, "Deze productnaam bestaat al");
            }
            else if (ModelState.IsValid)
            {
                _context.Update(productViewModel.Product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            productViewModel.Afdeling = new SelectList(_context.Afdelingen, "AfdelingId", "Naam", productViewModel.Product.AfdelingId);
            return View(productViewModel);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Producten
                .Include(p => p.Afdeling)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Producten.FindAsync(id);
            _context.Producten.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Producten.Any(e => e.ProductId == id);
        }
    }
}