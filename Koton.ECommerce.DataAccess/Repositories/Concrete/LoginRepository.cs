using Dapper;
using Koton.ECommerce.Core.DTOs;
using Koton.ECommerce.DataAccess.Repositories.Abstract;
using Microsoft.Data.SqlClient;

namespace Koton.ECommerce.DataAccess.Repositories.Concrete
{
    public class LoginRepository : ILoginRepository
    {

        public async Task<UserInfoDto> GetUserInfoAsync(string username, string password)
        {
            using (var connection = new SqlConnection("Server=;Database=;Integrated Security = true; MultipleActiveResultSets = True;TrustServerCertificate=true; Application Name = Koton.ECommerce "))
            {
                var userInfo = await connection.QueryFirstOrDefaultAsync<UserInfoDto>(sql: " Select UserName, Password,IsActive from Users Where Username =  ",
                    // dapper ile sorgu çalıştırıken, parametre kullanımı
                    commandTimeout: 3000);
                return userInfo;
            }
        }
    }
}
