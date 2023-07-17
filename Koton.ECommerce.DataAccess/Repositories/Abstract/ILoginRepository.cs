using Koton.ECommerce.Core.DTOs;

namespace Koton.ECommerce.DataAccess.Repositories.Abstract
{
    public interface ILoginRepository
    {
        Task<UserInfoDto> GetUserInfoAsync(string username, string password);
    }
}
