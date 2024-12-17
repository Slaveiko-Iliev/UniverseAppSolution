namespace UniverseApp.Infrastructure.Common
{
    public interface ISeedHelper
    {
        public Task<List<T>> GetEntityIdDtoAsync<T>();
        public Task<List<T>> GetEntityDtoInfoAsync<T>(List<T> entities);
        Task<ICollection<T>> GetMovieDtoInfoAsync<T>();
    }
}
