using Microsoft.AspNetCore.Mvc;
using Scratch_Cards_APP.Services;

namespace Scratch_Cards_APP.Controllers;
public class ScratchCardsController : Controller
{
    private readonly ScratchCardsService _cardsService;

    public ScratchCardsController(ScratchCardsService cardsService)
    {
        _cardsService = cardsService;
    }

    public async Task<IActionResult> Index()
    {
        var cards = await _cardsService.GetCardsAsync();

        if (cards is null)
        {
            return View("Error");
        }

        return View(cards);
    }

    public async Task<IActionResult> Details(int id)
    {
        var card = await _cardsService.GetCardByIdAsync(id);

        if (card is null)
        {
            return NotFound();
        }

        return View(card);
    }

    [HttpPost]
    public async Task<IActionResult> Purchase(int id)
    {
        await _cardsService.PurchaseCardAsync(id);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Use(int id)
    {
        await _cardsService.UseCardAsync(id);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Generate()
    {
        await _cardsService.GenerateCardAsync();

        return RedirectToAction(nameof(Index));
    }
}
