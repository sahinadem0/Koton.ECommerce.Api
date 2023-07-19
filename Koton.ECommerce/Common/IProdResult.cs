using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.ECommerce.Core.Common
{
    public interface IProdResult<T>
    {
         bool IsSuccess { get; set; }
         string Message { get; set; }
         T Data { get; set; }
    }
}
