using FarmStore3.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmStore3.Models
{
    public class ProductListItemViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ProductListItemViewModel(FarmDALModel dalModel)
        {
            ID = dalModel.ProduceID;
            Name = dalModel.ProduceName;
        }
    }
}
