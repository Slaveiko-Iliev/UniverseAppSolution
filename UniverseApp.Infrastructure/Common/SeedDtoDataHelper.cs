using System.Text.Json;
using System.Text.RegularExpressions;
using UniverseApp.Infrastructure.Data.DTOs;

namespace UniverseApp.Infrastructure.Common
{
    public static class SeedDtoDataHelper
    {
        public static async Task<List<T>> GetEntityDtoInfoAsync<T>()
        {
            List<T> entityDtoList = new List<T>();

            var result = new ResultTDto<T>()
            { Next = "" };

            var client = new HttpClient();

            string url = (typeof(T).Name) switch
            {
                "PlanetInfoDto" => "https://swapi.dev/api/planets",
                "StarshipInfoDto" => "https://swapi.dev/api/starships",
                "VehicleInfoDto" => "https://swapi.dev/api/vehicles",
                "SpecieInfoDto" => "https://swapi.dev/api/species",
                "MovieInfoDto" => "https://swapi.dev/api/films",
                "CharacterInfoDto" => "https://swapi.dev/api/people",
                _ => "https://swapi.dev/api"
            };

            var option = new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true };

            while (result != null && result.Next != null)
            {
                var response = await client.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<ResultTDto<T>>(responseContent, option);
                entityDtoList.AddRange(result!.Results);
                url = result.Next;
            }

            return entityDtoList;
        }

        public static int GetEntityIdFromUrl(string url)
        {
            string pattern = @"(\d+)";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(url);

            return int.Parse(match.Value);
        }

        public static string[] SplitInput(string input) =>
            input.Split(", ", StringSplitOptions.RemoveEmptyEntries) ?? [];

        public static int? TryParseInputToInt(string input) =>
            int.TryParse(input, out int result) ? result : null;

        public static double? TryParseInputToDouble(string input) =>
            double.TryParse(input, out double result) ? result : null;
    }
}
