using Microsoft.AspNetCore.Mvc;
using StockManagementSystem.Interfaces;
using StockManagementSystem.Models;

namespace StockManagementSystem.Controllers
{
    public class SalesController : Controller
    {
        private readonly IUnitOfWork _uow;

        public SalesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Laptops = await _uow.Laptops.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Sale sale)
        {

            var laptop = await _uow.Laptops.GetByIdAsync(sale.LaptopId);

            if (laptop.StockQty < sale.Qty)
                return BadRequest("Out of stock");

            laptop.StockQty -= sale.Qty;

            sale.SaleDate = DateTime.Now; 

            await _uow.Sales.InsertAsync(sale);
            _uow.Laptops.Update(laptop);

            await _uow.SaveAsync();
            return RedirectToAction("List");
        }

        public async Task<IActionResult> List()
        {
            var sales = await _uow.Sales.GetAllAsync();
            return View(sales);
        }
    }
}
