namespace UniverseApp.Infrastructure.Data.DTOs
{
    public class Result<T>
    {
        public T Properties { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public string Uid { get; set; }
    }
}
