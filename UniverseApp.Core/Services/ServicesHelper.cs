using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
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

        public string[] SplitInput(string input) =>
            input != null
            ? input.Split(", ", StringSplitOptions.RemoveEmptyEntries)
            : new string[0];

        public int[] GetParsedIds(string input)
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

        public async Task<ICollection<T>> GetEntitiesByIds<T>(int[] ids) where T : class
        {
            return await _repository.AllReadOnly<T>().Where(x => ids.Contains((int)x.GetType().GetProperty("Id").GetValue(x))).ToArrayAsync();
        }
        public int? TryParseInputToInt(string input) =>
            int.TryParse(input, out int result) ? result : null;

        public double? TryParseInputToDouble(string input) =>
            double.TryParse(input, out double result) ? result : null;

        public int GetEntityIdFromUrl(string url)
        {
            string pattern = @"(\d+)";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(url);

            return int.Parse(match.Value);
        }
    }
}
