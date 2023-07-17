namespace Koton.ECommerce.Core.Common
{
    public class Result<T> : IResult<T>
    {
        public Result()
        {
        }

        public Result(bool isSuccess, string message, T data)
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
