using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Winkellijst_ASP.Data;
using Winkellijst_ASP.Models;

namespace Winkellijst_ASP.Controllers
{
    [Authorize]
    public class WinkelLijstProductController : Controller
    {
        private readonly GebruikerContext _context;

        public WinkelLijstProductController(GebruikerContext context)
        {
            _context = context;
        }

        // GET: WinkelLijstProduct
        public async Task<IActionResult> Index()
        {
            var gebruikerContext = _context.WinkelLijstProduct.Include(w => w.Product).Include(w => w.WinkelLijst);
            return View(await gebruikerContext.ToListAsync());
        }

        // GET: WinkelLijstProduct/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var winkelLijstProduct = await _context.WinkelLijstProduct
                .Include(w => w.Product)
                .Include(w => w.WinkelLijst)
                .FirstOrDefaultAsync(m => m.WinkelLijstProductId == id);
            if (winkelLijstProduct == null)
            {
                return NotFound();
            }

            return View(winkelLijstProduct);
        }

        // GET: WinkelLijstProduct/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Producten, "ProductId", "Beschrijving");
            ViewData["WinkelLijstId"] = new SelectList(_context.WinkelLijsten, "WinkelLijstId", "Naam");
            return View();
        }

        // POST: WinkelLijstProduct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WinkelLijstProductId,Aantal,WinkelLijstId,ProductId")] WinkelLijstProduct winkelLijstProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(winkelLijstProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Producten, "ProductId", "Beschrijving", winkelLijstProduct.ProductId);
            ViewData["WinkelLijstId"] = new SelectList(_context.WinkelLijsten, "WinkelLijstId", "Naam", winkelLijstProduct.WinkelLijstId);
            return View(winkelLijstProduct);
        }

        // GET: WinkelLijstProduct/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var winkelLijstProduct = await _context.WinkelLijstProduct.FindAsync(id);
            if (winkelLijstProduct == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Producten, "ProductId", "Beschrijving", winkelLijstProduct.ProductId);
            ViewData["WinkelLijstId"] = new SelectList(_context.WinkelLijsten, "WinkelLijstId", "Naam", winkelLijstProduct.WinkelLijstId);
            return View(winkelLijstProduct);
        }

        // POST: WinkelLijstProduct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WinkelLijstProductId,Aantal,WinkelLijstId,ProductId")] WinkelLijstProduct winkelLijstProduct)
        {
            if (id != winkelLijstProduct.WinkelLijstProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(winkelLijstProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WinkelLijstProductExists(winkelLijstProduct.WinkelLijstProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Producten, "ProductId", "Beschrijving", winkelLijstProduct.ProductId);
            ViewData["WinkelLijstId"] = new SelectList(_context.WinkelLijsten, "WinkelLijstId", "Naam", winkelLijstProduct.WinkelLijstId);
            return View(winkelLijstProduct);
        }

        // GET: WinkelLijstProduct/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var winkelLijstProduct = await _context.WinkelLijstProduct
                .Include(w => w.Product)
                .Include(w => w.WinkelLijst)
                .FirstOrDefaultAsync(m => m.WinkelLijstProductId == id);
            if (winkelLijstProduct == null)
            {
                return NotFound();
            }

            return View(winkelLijstProduct);
        }

        // POST: WinkelLijstProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var winkelLijstProduct = await _context.WinkelLijstProduct.FindAsync(id);
            _context.WinkelLijstProduct.Remove(winkelLijstProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WinkelLijstProductExists(int id)
        {
            return _context.WinkelLijstProduct.Any(e => e.WinkelLijstProductId == id);
        }
    }
}
