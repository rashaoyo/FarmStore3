using FarmStore3.DAL;
using FarmStore3.DAL.Models;
using FarmStore3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmStore3.FarmServices
{
    public interface IFarmService2
    {
        ProductViewModel GetAllProducts();
        Products GetProduct(int produceID);
        ProductViewModel AddNewProduct(AddProductViewModel model);
    }

    public class FarmService2 : IFarmService2
    {
        private readonly IFarmStore _farmStore;

        public FarmService2(IFarmStore farmStore)
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

        public ProductViewModel AddNewProduct(AddProductViewModel model)
        {
            var dalModel = MapToFarmDalModel(model);
            _farmStore.InsertNewProduct(dalModel);
            var dalProducts = _farmStore.SelectAllProducts();
            return MapProductsViewModel(dalProducts);
            //var dalModel = new FarmDALModel();
            //dalModel.ProduceName = model.ProduceName;
            //_productStore.InsertNewProduct(dalModel);

            ////MAPPING
            //var dalProducts = _productStore.SelectAllProduct();
            //var products = new List<Products>();

            //foreach (var dalProduct in dalProducts)
            //{
            //    var product = new Products();
            //    product.ProduceName = dalProduct.ProduceName;
            //    products.Add(product);
            //}

            //var ProductViewModel = new ProductViewModel();
            //ProductViewModel.Products = products;

            //return ProductViewModel;
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
       
    }
}
