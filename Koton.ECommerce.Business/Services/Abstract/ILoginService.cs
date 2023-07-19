using Koton.ECommerce.Core.Common;

namespace Koton.ECommerce.Business.Services.Abstract
{
    public interface ILoginService
    {
        Task<Result<string>> LoginAsync(string email, string password);
    }
}
