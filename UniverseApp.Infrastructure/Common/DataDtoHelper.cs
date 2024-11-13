using System.Text.Json;
using UniverseApp.Infrastructure.Data.DTOs;

namespace UniverseApp.Infrastructure.Common
{
    internal static class DataDtoHelper
    {
        internal static async Task<List<T>> GetEntityDtoInfoAsync<T>()
        {
            List<T> entityDtoList = new List<T>();

            var result = new ResultTDto<T>()
            { Next = "" };

            var client = new HttpClient();

            string url = (typeof(T).Name) switch
            {
                "PlanetInfoDto" => url = "https://swapi.dev/api/planets",
                "StarshipInfoDto" => url = "https://swapi.dev/api/starships",
                "VehicleInfoDto" => url = "https://swapi.dev/api/vehicles",
                "SpecieInfoDto" => url = "https://swapi.dev/api/species",
                "MovieInfoDto" => url = "https://swapi.dev/api/films",
                "CharacterInfoDto" => url = "https://swapi.dev/api/people",
                _ => url = "https://swapi.dev/api"
            };

            var option = new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true };

            while (result != null && result.Next != null)
            {
                var responce = await client.GetAsync(url);
                var responceContent = await responce.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<ResultTDto<T>>(responceContent, option);
                entityDtoList.AddRange(result!.Results);
                url = result.Next;
            }

            return entityDtoList;
        }
    }
}
