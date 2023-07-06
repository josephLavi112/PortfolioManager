using static StockDatabase1.Models.Stock;
using StockDatabase1.Models;

namespace PortfolioManager
{
    namespace StockDatabase1
    {
        public interface IStockRepo
        {
            public IEnumerable<Stock> GetAllStocks();
            public Stock GetStock(int StockID);
            public void UpdateStock(Stock stock);
            public void InsertStock(Stock StockToInsert);
            public IEnumerable<Stock> GetStocks();
            public void DeleteStock(Stock stock);

        }
    }
}
