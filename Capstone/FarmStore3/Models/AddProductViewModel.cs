using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmStore3.Models
{
    public class AddProductViewModel
    {
        public string ProduceName { get; set; }
        public int ProduceID { get; set; }
        public int StockQuantity { get; set; }
        public int UnitPrice { get; set; }
        public bool InSeason { get; set; }
    }
}
