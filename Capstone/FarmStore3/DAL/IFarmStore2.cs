using Dapper;
using FarmStore3.DAL.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FarmStore3.DAL
{
    public interface IFarmStore2
    {
        IEnumerable<FarmDALModel> SelectAllProducts();
        FarmDALModel SelectProduceByProduceName(string produceName);
        FarmDALModel SelectProduceByProduceID(int produceID);
        bool InsertNewProduct(FarmDALModel dalModel);

    }

    public class FarmStore2 : IFarmStore2
    {
        private readonly Database _config;

        public FarmStore2(FarmStore3Configuration config)
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
