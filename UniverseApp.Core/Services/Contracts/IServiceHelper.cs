namespace UniverseApp.Core.Services.Contracts
{
    public interface IServiceHelper
    {
        string[] SplitInput(string input);
        Task<ICollection<T>> GetEntitiesByIds<T>(int[] ids) where T : class;
        Task<int[]> GetIdsOfEntitiesAsync<T>(ICollection<T> entities) where T : class;
    }
}
