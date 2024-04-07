using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Word_Guesser.Data;
using Word_Guesser.Data.Data.Entities;
using Word_Guesser.Services.Abstarctions;
using Word_Guesser.Services.DTOs;

namespace Word_Guesser.Controllers
{
    public class PicturesController : Controller
    {
        private readonly ITranslationsService _translationService;
        private readonly ILanguagesService _languagesService;
        private readonly IWordsService _wordsService;
        private readonly IPictureService _pictureService;
        public PicturesController(ITranslationsService translationService, ILanguagesService languagesService, IWordsService wordsService, IPictureService pictureService)
        {
            _translationService = translationService;
            _languagesService = languagesService;
            _wordsService = wordsService;
            _pictureService = pictureService;
        }

        // GET: Pictures
        public async Task<IActionResult> Index()
        {
            return View(await _pictureService.GetPicturesAsync());
        }

        // GET: Pictures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _pictureService.GetPicturesByIdAsync(id.Value);
            if (picture == null)
            {
                return NotFound();
            }

            return View(picture);
        }

        // GET: Pictures/Create
        public async Task<IActionResult> CreateAsync()
        {
            ViewBag.WordId = new SelectList(await _wordsService.GetWordsAsync(), "Id", "Identifier");
            return View(new PictureCreateOrEditDTO());
        }

        // POST: Pictures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PictureCreateOrEditDTO picture)
        {
            if (ModelState.IsValid)
            {
                await _pictureService.AddPicturesAsync(picture);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.WordId = new SelectList(await _wordsService.GetWordsAsync(), "Id", "Identifier");
            return View(picture);
        }

        // GET: Pictures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _pictureService.GetPicturesByIdAsync(id.Value);
            if (picture == null)
            {
                return NotFound();
            }
            ViewBag.WordId = new SelectList(await _wordsService.GetWordsAsync(), "Id", "Identifier", picture.Word.Id);

            return View(new PictureCreateOrEditDTO()
            {
                Id = picture.Id,
                Filename = picture.Filename,
                WordId = picture.Word.Id
            });
        }

        // POST: Pictures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PictureCreateOrEditDTO picture)
        {
            if (id != picture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _pictureService.UpdatePicturesAsync(picture);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PictureExists(picture.Id))
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
            ViewBag.WordId = new SelectList(await _wordsService.GetWordsAsync(), "Id", "Identifier", picture.WordId);
            return View(picture);
        }

        // GET: Pictures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _pictureService.GetPicturesByIdAsync(id.Value);
            if (picture == null)
            {
                return NotFound();
            }

            return View(picture);
        }

        // POST: Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var picture = await _pictureService.GetPicturesByIdAsync(id);
            if (picture != null)
            {
                await _pictureService.DeletePicturesByIdAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PictureExists(int id)
        {
            var language = await _languagesService.GetLanguagesByIdAsync(id);
            return language != null;
        }
    }
}
