using Koton.ECommerce.Core.Common;
using Koton.ECommerce.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.ECommerce.Business.Services.Abstract
{
    public interface IProductService
    {

        Task<Result<IEnumerable<GetProductDto>>> GetProductsAsync();
        Task<Result<GetProductDto>> GetProductByIdAsync(int id);

    }
}
