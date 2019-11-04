using Dapper;
using FarmStore3.DAL.Models;
using FarmStore3.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FarmStore3.DAL
{
    public interface IFarmStore
    {
        IEnumerable<FarmDALModel> SelectAllProducts();
        FarmDALModel SelectProduceByProduceName(string produceName);
        FarmDALModel SelectProduceByProduceID(int produceID);
        bool InsertNewProduct(FarmDALModel dalModel);

        bool UpdateProduct(int ProduceId, Products updatedProduct);
        bool DeleteTheProduct(FarmDALModel dalModel);
    }

    public class ProductStore : IFarmStore
    {
        private readonly Database _config;

        public ProductStore(FarmStore3Configuration config)
        {
            _config = config.Database;
        }


        public IEnumerable<FarmDALModel> SelectAllProducts()
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

        public bool DeleteTheProduct(FarmDALModel dalModel)
        {

            var sql = @"Delete from Produce where produceID = @ProduceID";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var result = connection.Execute(sql, new { ProduceID = $"%{dalModel.ProduceID}%" });
                return true;
            }
        }

        public FarmDALModel SelectProduceByProduceName(string produceName)
        {
            var sql = @"SELECT * FROM Produce WHERE ProduceName LIKE @ProduceName";
            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var result = connection.QueryFirstOrDefault<FarmDALModel>(sql, new { ProduceName = $"%{produceName}%" });
                return result;
            }
        }

        public FarmDALModel SelectProduceByProduceID(int produceID)
        {
            var sql = @"SELECT * FROM Produce where ProduceID = @ProduceID";

            using (var connection = new SqlConnection(_config.ConnectionString))
            {
                var result = connection.QueryFirstOrDefault<FarmDALModel>(sql, new { ProduceID = produceID });
                return result;
            }
        }


    }
}
