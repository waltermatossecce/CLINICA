namespace CLINICA.Application.UseCase.Commons.Base
{
    public class BaseResponse<T>
    {
        public bool IsSucess { get; set; }
        public T? data { get; set; }
        public string? Message { get; set; }
        public IEnumerable<BaseError>? Errors { get; set; }
    }
}
