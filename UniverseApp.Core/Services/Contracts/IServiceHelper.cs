namespace UniverseApp.Core.Services.Contracts
{
    public interface IServiceHelper
    {
        string[] SplitInput(string input);
        int[] GetParsedIds(string input);
        Task<ICollection<T>> GetEntitiesByIds<T>(ICollection<int> ids) where T : class;
    }
}
