using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koton.ECommerce.Core.Common
{
    public class ProdResult<T> : IProdResult<T>
    {
        public ProdResult()
        {
        }

        public ProdResult(bool isSuccess, string message, T data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
