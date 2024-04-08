using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Word_Guesser.Data;
using Word_Guesser.Data.Data.Entities;
using Word_Guesser.Services.Abstarctions;
using Word_Guesser.Services.DTOs;

namespace Word_Guesser.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly ITranslationsService _translationService;
        private readonly ILanguagesService _languagesService;
        private readonly IWordsService _wordsService;
        public LanguagesController(ITranslationsService translationService, ILanguagesService languagesService, IWordsService wordsService)
        {
            _translationService = translationService;
            _languagesService = languagesService;
            _wordsService = wordsService;
        }


            // GET: Languages
            public async Task<IActionResult> Index()
        {
            return View(await _languagesService.GetLanguagesAsync());
        }

        // GET: Languages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _languagesService.GetLanguagesByIdAsync(id.Value);
            if (language == null)
            {
                return NotFound();
            }


            return View(language);
        }

        // GET: Languages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Languages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LanguageDTO language)
        {
            if (ModelState.IsValid)
            {
                await _languagesService.AddLanguagesAsync(language);
                return RedirectToAction(nameof(Index));
            }
            return View(language);
        }

        // GET: Languages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var language = await _languagesService.GetLanguagesByIdAsync(id.Value);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }

        // POST: Languages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LanguageDTO language)
        {
            if (id != language.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _languagesService.UpdateLanguagesAsync(language);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await LanguageExists(language.Id))
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
            return View(language);
        }

        // GET: Languages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var language = await _languagesService.GetLanguagesByIdAsync(id.Value);
            if (language == null)
            {
                return NotFound();
            }

            return View(language);
        }

        // POST: Languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var language = await _languagesService.GetLanguagesByIdAsync(id);
            if (language != null)
            {
                await _languagesService.DeleteLanguagesByIdAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> LanguageExists(int id)
        {
            var language = await _languagesService.GetLanguagesByIdAsync(id);
            return language != null;
        }
    }
}
