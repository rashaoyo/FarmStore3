using Dapper;
using FarmStore3.DAL.Models;
using FarmStore3.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FarmStore3.DAL
{
    public interface IFarmStore
    {
        IEnumerable<FarmDALModel> SelectAllProduct();

        bool InsertNewProduct(FarmDALModel dalModel);

        bool UpdateProduct(int ProduceId, Products updatedProduct);

    }

    public class ProductStore : IFarmStore
    {
        private readonly Database _config;

        public ProductStore(FarmStore3Configuration config)
        {
            _config = config.Database;
        }


        public IEnumerable<FarmDALModel> SelectAllProduct()
        {
            var sql = @"SELECT * FROM Produce";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var result = connection.Query<FarmDALModel>(sql);

                return result;
            }
        }
        public bool InsertNewProduct(FarmDALModel dalModel)
        {
            //ADD PRODUCT
            var sql = $@"Insert INTO Produce (ProduceName) Values (@{nameof(dalModel.ProduceName)})";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var result = connection.Execute(sql, dalModel);

                return true;
            }

        }

        public bool UpdateProduct(int ProduceId, Products updatedProduct)
        {
            updatedProduct.ProduceID = ProduceId;

            var sql = @"update Produce Set ProduceID = @ProduceID, 
                                            ProduceName = @ProduceName,
                                            StockQuantity = @StockQuantity,
                                            CartQuantity = @CartQuantity,
                                            UnitPrice = @UnitPrice,
                                            InSeason = @InSeason";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var result = connection.Execute(sql, updatedProduct);
                return true;
            }
        }


    }
}
