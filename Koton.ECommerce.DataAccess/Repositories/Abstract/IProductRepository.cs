using Koton.ECommerce.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.ECommerce.DataAccess.Repositories.Abstract
{
    public interface IProductRepository
    {

        Task<IEnumerable<GetProductDto>> GetProducts();
        Task<GetProductDto> GetProductById(int id);

    }
}
