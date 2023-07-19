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
            using (var connection = new SqlConnection("Server=DESKTOP-UIC5F07\\SQLEXPRESS;Database=kotonECommerce;Integrated Security=true;MultipleActiveResultSets=True;TrustServerCertificate=true;Application Name=Koton.ECommerce"))
            {
                // Filter the query based on the provided username and password.
                var userInfo = await connection.QueryFirstOrDefaultAsync<UserInfoDto>(
                    sql: "SELECT Username, PasswordHash, Email FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash",
                    param: new { Username = username, PasswordHash = password },
                    commandTimeout: 0);

                return userInfo;
            }
        }
    }
}
