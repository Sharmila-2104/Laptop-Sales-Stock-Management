using Microsoft.AspNetCore.Mvc;
using StockManagementSystem.Interfaces;
using StockManagementSystem.Models;

namespace StockManagementSystem.Controllers
{
    public class LaptopController : Controller
    {
        private readonly IUnitOfWork _uow;

        public LaptopController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Index()
            => View(await _uow.Laptops.GetAllAsync());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Laptop laptop)
        {
            if (!ModelState.IsValid)
                return View(laptop);

            await _uow.Laptops.InsertAsync(laptop);
            await _uow.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var laptop = await _uow.Laptops.GetByIdAsync(id);

            if (laptop == null)
                return NotFound();

            return View(laptop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Laptop laptop)
        {
            if (!ModelState.IsValid)
                return View(laptop);

            _uow.Laptops.Update(laptop);
            await _uow.SaveAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _uow.Laptops.GetByIdAsync(id);
            _uow.Laptops.Delete(item);
            await _uow.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
