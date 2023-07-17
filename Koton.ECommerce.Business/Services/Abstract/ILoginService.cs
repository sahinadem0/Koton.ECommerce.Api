using Koton.ECommerce.Core.Common;

namespace Koton.ECommerce.Business.Services.Abstract
{
    public interface ILoginService
    {
        Task<Result<bool>> LoginAsync(string username, string password);
    }
}
