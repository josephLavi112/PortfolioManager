
namespace StockDatabase1.Models
{
        public class Stock
        {       

            public int StockID { get; set; }
            public string Symbol { get; set; }
            public string CompanyName { get; set; }
            public double CurrentPrice { get; set; }
            public double MarketCap { get; set; }
            public string Sector { get; set; }
            public string Industry { get; set; }
            public string Country { get; set; }
           

        }    
}
