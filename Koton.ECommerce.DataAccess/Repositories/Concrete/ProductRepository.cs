using Dapper;
using Koton.ECommerce.Core.DTOs;
using Koton.ECommerce.DataAccess.Repositories.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.ECommerce.DataAccess.Repositories.Concrete
{
    public class ProductRepository : IProductRepository
    {
        public async Task<IEnumerable<GetProductDto>> GetProducts()
        {
            using (var connection = new SqlConnection("Server=DESKTOP-UIC5F07\\SQLEXPRESS;Database=kotonECommerce;Integrated Security=true;MultipleActiveResultSets=True;TrustServerCertificate=true;Application Name=Koton.ECommerce"))
            {
                // Retrieve all products.
                var products = await connection.QueryAsync<GetProductDto>("SELECT * FROM Products");

                return products;
            }
        }

        public async Task<GetProductDto> GetProductById(int id)
        {
            using (var connection = new SqlConnection("Server=DESKTOP-UIC5F07\\SQLEXPRESS;Database=kotonECommerce;Integrated Security=true;MultipleActiveResultSets=True;TrustServerCertificate=true;Application Name=Koton.ECommerce"))
            {
                // Retrieve the product with the specified id.
                var product = await connection.QueryFirstOrDefaultAsync<GetProductDto>("SELECT * FROM Products WHERE Id = @Id", new { Id = id });

                return product;
            }
        }

    }
}
