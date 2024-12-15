namespace UniverseApp.Core.Services.Contracts
{
    public interface IServiceHelper
    {
        string[] SplitInput(string input);

        int[] GetParsedIds(string input);

        Task<ICollection<T>> GetEntitiesByIds<T>(int[] ids) where T : class;

        int? TryParseInputToInt(string input);

        double? TryParseInputToDouble(string input);
    }
}
