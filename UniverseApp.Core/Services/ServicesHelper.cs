using Microsoft.EntityFrameworkCore;
using UniverseApp.Core.Services.Contracts;
using UniverseApp.Infrastructure.Common;

namespace UniverseApp.Core.Services
{
    public class ServicesHelper : IServiceHelper
    {
        private readonly IRepository _repository;

        public ServicesHelper(IRepository repository)
        {
            _repository = repository;
        }

        public string[] SplitInput(string input) => input != null ? input.Split(", ", StringSplitOptions.RemoveEmptyEntries) : new string[0];

        public ICollection<int> GetParsedIds(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return Array.Empty<int>();
            }

            return input
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        public async Task<ICollection<T>> GetEntitiesByIds<T>(int[] ids) where T : class =>
            await _repository
                .AllReadOnly<T>()
                .Where(x => ids.Contains((int)x.GetType().GetProperty("Id").GetValue(x)))
                .ToArrayAsync();

        public async Task<int[]> GetIdsOfEntitiesAsync<T>(ICollection<T> entities) where T : class =>
            await Task.FromResult(entities.Select(x => (int)x.GetType().GetProperty("Id").GetValue(x))
                .ToArray());
    }
}