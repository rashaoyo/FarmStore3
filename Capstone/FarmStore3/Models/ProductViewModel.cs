namespace FarmStore3.Models
{
    public class ProductViewModel
    {
        public int ProduceID { get; set; }
        public string ProduceName { get; set; }
        public int StockQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public bool InSeason { get; set; }
    }
}
