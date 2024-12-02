using System.Text.Json;
using UniverseApp.Infrastructure.Data.DTOs;

namespace UniverseApp.Infrastructure.Common
{
    public static class DataDtoHelper
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
    }
}
