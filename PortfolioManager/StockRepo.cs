
using Dapper;
using StockDatabase1.Models;
using System.Data;
using static StockDatabase1.Models.Stock;
namespace PortfolioManager
{
    namespace StockDatabase1
    {
        public class StockRepo : IStockRepo
        {
            private readonly IDbConnection _conn;
            public StockRepo(IDbConnection conn)
            {
                _conn = conn;
            }
            public IEnumerable<Stock> GetAllStocks()
            {
                return _conn.Query<Stock>("SELECT * FROM STOCKS;");
            }
            public Stock GetStock(int id)
            {
                return _conn.QuerySingle<Stock>("SELECT * FROM STOCKS WHERE StockID = @id", new { id = id });
            }
            public void UpdateStock(Stock Stock)
            {
                _conn.Execute("UPDATE stocks SET CompanyName = @Name, CurrentPrice = @Price WHERE StockID = @ID",
                 new { Name = Stock.CompanyName, Price = Stock.CurrentPrice, ID = Stock.StockID });
            }
            public void InsertStock(Stock stockToInsert)
            {
                _conn.Execute("INSERT INTO Stocks (SYMBOl, COMPANYNAME, CURRENTPRICE, MARKETCAP, SECTOR, INDUSTRY, COUNTRY) VALUES (@symbol, @companyname, @currentprice, @marketcap, @sector, @industry, @country);",
                    new { symbol = stockToInsert.Symbol, companyname = stockToInsert.CompanyName, currentprice = stockToInsert.CurrentPrice, marketcap = stockToInsert.MarketCap, sector = stockToInsert.Sector, industry = stockToInsert.Industry, country = stockToInsert.Country });
            }
            public IEnumerable<Stock> GetStocks()
            {
                return _conn.Query<Stock>("SELECT * FROM Stocks;");
            }
            public void DeleteStock(Stock stock)
            {
                _conn.Execute("DELETE FROM Stocks WHERE StockID = @id;", new { id = stock.StockID });

            }


        }
    }
}
