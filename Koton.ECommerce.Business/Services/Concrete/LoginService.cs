using Koton.ECommerce.Business.Services.Abstract;
using Koton.ECommerce.Core.Common;
using Koton.ECommerce.DataAccess.Repositories.Abstract;

namespace Koton.ECommerce.Business.Services.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<Result<bool>> LoginAsync(string username, string password)
        {
            // logging
            // validation
            // tür dönüşümleri, Entity nesnelerinin yaratılması

            var userInfo = await _loginRepository.GetUserInfoAsync(username, password);
            if (userInfo != null)
            {
                return new Result<bool> { IsSuccess = true, Message = "Success" };
            }
            else
                return new Result<bool> { IsSuccess = false, Message = "User Bulunamadı" };
            
        }

    }
}
