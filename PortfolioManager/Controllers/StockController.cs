using Microsoft.AspNetCore.Mvc;
using PortfolioManager.StockDatabase1;
using StockDatabase1.Models;

namespace StockDatabase1.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockRepo repo;
        private object stockToInsert;

        public StockController(IStockRepo repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var stocks = repo.GetAllStocks();
            return View(stocks);
        }
        public IActionResult ViewStock(int id)
        {
            var stock = repo.GetStock(id);
            return View(stock);
        }
        public IActionResult UpdateStock(int id)
        {
            var stock = repo.GetStock(id);
            if (stock == null)
            {
                return View("StockNotFound");
            }
            return View(stock);
        }
        public IActionResult UpdateStockToDatabase(Stock Stock)
        {
            repo.UpdateStock(Stock);

            return RedirectToAction("ViewStock", new { id = Stock.StockID });
        }
        public IActionResult AddStock(Stock stock)
        {
            
            return View(stock);
        }
        public IActionResult InsertStockToDatabase(Stock StockToInsert)
        {
            repo.InsertStock(StockToInsert);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteStock(Stock stock)
        {
            repo.DeleteStock(stock);
            return RedirectToAction("Index");
        }

    }
}
