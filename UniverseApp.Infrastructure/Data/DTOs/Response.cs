namespace UniverseApp.Infrastructure.Data.DTOs
{
    public class Response<T>
    {
        public string Message { get; set; }
        public Result<T> Result { get; set; }
    }
}
