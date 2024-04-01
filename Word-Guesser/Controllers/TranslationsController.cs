using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Word_Guesser.Data;
using Word_Guesser.Data.Data.Entities;

namespace Word_Guesser.Controllers
{
    public class TranslationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TranslationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Translations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Transalations.Include(t => t.Language).Include(t => t.Word);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Translations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transalations == null)
            {
                return NotFound();
            }

            var translation = await _context.Transalations
                .Include(t => t.Language)
                .Include(t => t.Word)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (translation == null)
            {
                return NotFound();
            }

            return View(translation);
        }

        // GET: Translations/Create
        public IActionResult Create()
        {
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name");
            ViewData["WordId"] = new SelectList(_context.Words, "Id", "Identifier");
            return View();
        }

        // POST: Translations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WordId,LanguageId,Value,Id")] Translation translation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(translation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name", translation.LanguageId);
            ViewData["WordId"] = new SelectList(_context.Words, "Id", "Identifier", translation.WordId);
            return View(translation);
        }

        // GET: Translations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transalations == null)
            {
                return NotFound();
            }

            var translation = await _context.Transalations.FindAsync(id);
            if (translation == null)
            {
                return NotFound();
            }
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name", translation.LanguageId);
            ViewData["WordId"] = new SelectList(_context.Words, "Id", "Identifier", translation.WordId);
            return View(translation);
        }

        // POST: Translations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WordId,LanguageId,Value,Id")] Translation translation)
        {
            if (id != translation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(translation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TranslationExists(translation.Id))
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
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Name", translation.LanguageId);
            ViewData["WordId"] = new SelectList(_context.Words, "Id", "Identifier", translation.WordId);
            return View(translation);
        }

        // GET: Translations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transalations == null)
            {
                return NotFound();
            }

            var translation = await _context.Transalations
                .Include(t => t.Language)
                .Include(t => t.Word)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (translation == null)
            {
                return NotFound();
            }

            return View(translation);
        }

        // POST: Translations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transalations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Transalations'  is null.");
            }
            var translation = await _context.Transalations.FindAsync(id);
            if (translation != null)
            {
                _context.Transalations.Remove(translation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TranslationExists(int id)
        {
          return (_context.Transalations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
