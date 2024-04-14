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
    public class WordsController : Controller
    {
        private readonly ITranslationsService _translationService;
        private readonly ILanguagesService _languagesService;
        private readonly IWordsService _wordsService;
        private readonly IPictureService _pictureService;

        public WordsController(ITranslationsService translationService, ILanguagesService languagesService, IWordsService wordsService, IPictureService pictureService)
        {
            _translationService = translationService;
            _languagesService = languagesService;
            _wordsService = wordsService;
            _pictureService = pictureService;
        }

        // GET: Words
        public async Task<IActionResult> Index()
        {
            return View(await _wordsService.GetWordsAsync());
        }

        // GET: Words/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var word = await _wordsService.GetWordsByIdAsync(id.Value);
            if (word == null)
            {
                return NotFound();
            }

            return View(word);
        }

        // GET: Words/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Words/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WordDTO word)
        {
            if (ModelState.IsValid)
            {
                await _wordsService.AddWordsAsync(word);
                return RedirectToAction(nameof(Index));
            }
            return View(word);
        }

        // GET: Words/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var word = await _wordsService.GetWordsByIdAsync(id.Value);
            if (word == null)
            {
                return NotFound();
            }
            return View(word);
        }

        // POST: Words/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WordDTO word)
        {
            if (id != word.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _wordsService.UpdateWordsAsync(word);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await WordExists(word.Id))
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
            return View(word);
        }

        // GET: Words/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var word = await _wordsService.GetWordsByIdAsync(id.Value);
            if (word == null)
            {
                return NotFound();
            }

            return View(word);
        }

        // POST: Words/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var word = await _wordsService.GetWordsByIdAsync(id);
            if (word != null)
            {
                await _wordsService.DeleteWordsByIdAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> WordExists(int id)
        {
            var word = await _wordsService.GetWordsByIdAsync(id);
            return word != null;
        }
    }
}
