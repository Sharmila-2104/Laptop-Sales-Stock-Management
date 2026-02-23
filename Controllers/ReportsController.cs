using Microsoft.AspNetCore.Mvc;
using StockManagementSystem.Interfaces;

namespace StockManagementSystem.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IUnitOfWork _uow;

        public ReportsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> EndingStock()
        {
            var data = await _uow.Laptops.GetAllAsync();
            return View(data);
        }
    }
}
