namespace UniverseApp.Infrastructure.Data.DTOs
{
    public class MovieResponse<T>
    {
        public string Message { get; set; }
        public MovieResult<T>[] Result { get; set; }
    }
}
