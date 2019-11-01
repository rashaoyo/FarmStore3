using FarmStore3.DAL;
using FarmStore3.DAL.Models;
using FarmStore3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmStore3.FarmServices
{
    public interface IFarmService
    {
        ProductViewModel GetProducts();

        ProductViewModel AddNewProduct(Products model);

        ProductViewModel UpdateProduce(int id, Products produce);
    }

    public class ProductService : IFarmService
    {
        private readonly IFarmStore _farmStore;

        public ProductService(IFarmStore farmStore)
        {
            _farmStore = farmStore;
        }

        public ProductViewModel GetProducts()
        {
            var dalProducts = _farmStore.SelectAllProduct();
            var products = new List<Products>();

            foreach (var dalProduct in dalProducts)
            {
                var product = new Products();
                product.ProduceName = dalProduct.ProduceName;
                product.ProduceID = dalProduct.ProduceID;
                products.Add(product);
            }
            var ProductViewModel = new ProductViewModel();
            ProductViewModel.Products = products;

            return ProductViewModel;
        }

        public ProductViewModel AddNewProduct(Products model)
        {
            var dalModel = new FarmDALModel();
            dalModel.ProduceName = model.ProduceName;
            _farmStore.InsertNewProduct(dalModel);

            //MAPPING
            var dalProducts = _farmStore.SelectAllProduct();
            var products = new List<Products>();

            foreach (var dalProduct in dalProducts)
            {
                var product = new Products();
                product.ProduceName = dalProduct.ProduceName;
                products.Add(product);
            }

            var ProductViewModel = new ProductViewModel();
            ProductViewModel.Products = products;

            return ProductViewModel;
        }

        public ProductViewModel UpdateProduce(int id, Products produce)
        {
            _farmStore.UpdateProduct(id, produce);
            throw new NotImplementedException();
        }

        public ProductViewModel DeletAProduct(Products model)
        {
            var dalModel = new FarmDALModel();
            dalModel.ProduceName = model.ProduceName;
            _farmStore.DeleteTheProduct(dalModel);

            //MAPPING
            var dalProducts = _farmStore.SelectAllProduct();
            var products = new List<Products>();

            foreach (var dalProduct in dalProducts)
            {
                var product = new Products();
                product.ProduceName = dalProduct.ProduceName;
                products.Add(product);
            }

            var ProductViewModel = new ProductViewModel();
            ProductViewModel.Products = products;

            return ProductViewModel;
        }
    }
}
