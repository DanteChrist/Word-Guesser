using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer.Localisation.NumberToWords;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Word_Guesser.Data;
using Word_Guesser.Data.Data.Entities;
using Word_Guesser.Services;
using Word_Guesser.Services.Abstarctions;
using Word_Guesser.Services.DTOs;

namespace Word_Guesser.Controllers
{
    public class TranslationsController : Controller
    {
        private readonly ITranslationsService _translationService;
        private readonly ILanguagesService _languagesService;
        private readonly IWordsService _wordsService;
        public TranslationsController(ITranslationsService translationService, ILanguagesService languagesService, IWordsService wordsService)
        {
            _translationService = translationService;
            _languagesService = languagesService;
            _wordsService = wordsService;
        }

        // GET: Translations
        public async Task<IActionResult> Index()
        {
            return View(await _translationService.GetTranslationsAsync());
        }

        // GET: Translations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translation = await _translationService.GetTranslationsByIdAsync(id.Value);
            if (translation == null)
            {
                return NotFound();
            }


            return View(translation);
        }

        // GET: Translations/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.LanguageId = new SelectList(await _languagesService.GetLanguagesAsync(), "Id", "Name");
            ViewBag.WordId = new SelectList(await _wordsService.GetWordsAsync(), "Id", "Identifier");
            return View(new TranslationCreateOrEditDTO());
        }

        // POST: Translations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TranslationCreateOrEditDTO translation)
        {
            if (ModelState.IsValid)
            {
                await _translationService.AddTranslationsAsync(translation);
                return RedirectToAction(nameof(Index));
            }

            ViewData["LanguageId"] = new SelectList(await _languagesService.GetLanguagesAsync(), "Id", "Name", translation.LanguageId);
            ViewData["WordId"] = new SelectList(await _wordsService.GetWordsAsync(), "Id", "Identifier", translation.WordId);
            return View(translation);
        }

        // GET: Translations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translation = await _translationService.GetTranslationsEditByIdAsync(id.Value);
            if (translation == null)
            {
                return NotFound();
            }

            return View(translation);
        }
        // POST: Translations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TranslationCreateOrEditDTO translation)
        {
            if (id != translation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _translationService.UpdateTranslationsAsync(translation);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await TranslationExists(translation.Id))
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
            return View(translation);
        }

        // GET: Translations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var translation = await _translationService.GetTranslationsByIdAsync(id.Value);
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

            var translation = await _translationService.GetTranslationsByIdAsync(id);
            if (translation != null)
            {
                await _translationService.DeleteTranslationsByIdAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TranslationExists(int id)
        {
            var translation = await _translationService.GetTranslationsByIdAsync(id);
            return translation != null;
        }
    }
}
