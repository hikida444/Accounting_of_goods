
using WinFormsApp1.Models;

namespace Accounting_of_goods.Models
{
    public class Supply
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; } // Цена закупки этой партии
        public decimal RateAtSupply { get; set; }  // Курс на момент закупки
        public string CurrencyAtSupply { get; set; }
        public DateTime SupplyDate { get; set; } = DateTime.UtcNow;
    }
}
