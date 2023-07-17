namespace Koton.ECommerce.Core.Common
{
    public interface IResult<T>
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
        T Data { get; set; }
    }
}
