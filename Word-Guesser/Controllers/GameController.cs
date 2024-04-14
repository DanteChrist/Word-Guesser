using Microsoft.AspNetCore.Mvc;
using Word_Guesser.Services.Abstarctions;

namespace Word_Guesser.Controllers
{
    public class GameController : Controller
    {
        private readonly IPictureService _pictureService;
        private readonly IWordsService _wordsService;
        public GameController(IPictureService pictureService, IWordsService wordsService)
        {
            _pictureService = pictureService;
            _wordsService = wordsService;

        }

        public async Task<IActionResult> Index()
        {
            var word = await  _wordsService.GetRandomWordAsync();
            ViewBag.Word = word;
            ViewBag.Pictures = await _pictureService.GetPicturesAnswersAsync(word.Id);
            return View();
        }

    }
}
