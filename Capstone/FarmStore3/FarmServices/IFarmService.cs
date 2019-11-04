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
        ProductViewModel GetAllProducts();
        Products GetProduct(int produceID);
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

        public ProductViewModel GetAllProducts()
        {
            var dalProducts = _farmStore.SelectAllProducts();
            return MapProductsViewModel(dalProducts);
            //var products = new List<Products>();

            //foreach (var dalProduct in dalProducts)
            //{
            //    var product = new Products();
            //    product.ProduceName = dalProduct.ProduceName;
            //    product.ProduceID = dalProduct.ProduceID;
            //    products.Add(product);
            //}
            //var ProductViewModel = new ProductViewModel();
            //ProductViewModel.product = products;

            //return ProductViewModel;
        }

        public ProductViewModel AddNewProduct(Products model)
        {
            var dalModel = new FarmDALModel();
            dalModel.ProduceName = model.ProduceName;
            _farmStore.InsertNewProduct(dalModel);

            //MAPPING
            var dalProducts = _farmStore.SelectAllProducts();
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
            var dalProducts = _farmStore.SelectAllProducts();

            return MapProductViewModel(dalProducts);
        }

        public Products GetProduct(int produceID)
        {
            var dalProduct = _farmStore.SelectProduceByProduceID(produceID);
            var product = MapProductViewModel(dalProduct);
            return product;
        }

        private Products MapProductViewModel(FarmDALModel dalProduct)
        {
            var product = new Products();
            product.ProduceName = dalProduct.ProduceName;
            product.ProduceID = dalProduct.ProduceID;
            product.UnitPrice = dalProduct.UnitPrice;
            product.StockQuantity = dalProduct.StockQuantity;
            product.InSeason = dalProduct.InSeason;
            return product;
        }

        private FarmDALModel MapToFarmDalModel(AddProductViewModel src)
        {
            var dalProduct = new FarmDALModel();
            dalProduct.ProduceName = src.ProduceName;
            dalProduct.ProduceID = src.ProduceID;
            dalProduct.StockQuantity = src.StockQuantity;
            dalProduct.UnitPrice = src.UnitPrice;
            dalProduct.InSeason = src.InSeason;
            return dalProduct;
        }

        private ProductViewModel MapProductsViewModel(IEnumerable<FarmDALModel> dalProducts)
        {
            var products = new List<ProductListItemViewModel>();

            foreach (var dalProduct in dalProducts)
            {
                products.Add(new ProductListItemViewModel(dalProduct));
            }

            var productViewModel = new ProductViewModel();
            productViewModel.ListOfProducts = products;

            return productViewModel;
        }

        public ProductViewModel DeletAProduct(Products model)
        {
            var dalModel = new FarmDALModel();
            dalModel.ProduceName = model.ProduceName;
            _farmStore.DeleteTheProduct(dalModel);

            //MAPPING
            var dalProducts = _farmStore.SelectAllProducts();
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
