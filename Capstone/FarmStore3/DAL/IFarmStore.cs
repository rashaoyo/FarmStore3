using Dapper;
using FarmStore3.DAL.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FarmStore3.DAL
{
    public interface IFarmStore
    {
        IEnumerable<FarmDALModel> SelectAllProduct();

        bool InsertNewProduct(FarmDALModel dalModel);

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

            using (var connection = new SqlConnection(_config.ConnectionSTring))
            {
                var result = connection.Query<FarmDALModel>(sql);

                return result;
            }
        }
        public bool InsertNewProduct(FarmDALModel dalModel)
        {
            //ADD PRODUCT
            var sql = $@"Insert INTO Produce (ProduceName) Values (@{nameof(dalModel.ProduceName)})";

            using (var connection = new SqlConnection(_config.ConnectionSTring))
            {
                var result = connection.Execute(sql, dalModel);

                return true;
            }

        }


    }
}
