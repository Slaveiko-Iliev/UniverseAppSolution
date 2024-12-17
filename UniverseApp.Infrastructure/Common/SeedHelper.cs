using System.Text.Json;
using System.Text.RegularExpressions;
using UniverseApp.Infrastructure.Data.DTOs;

namespace UniverseApp.Infrastructure.Common
{
    public class SeedHelper : ISeedHelper
    {
        public async Task<List<T>> GetEntityIdDtoAsync<T>()
        {
            List<T> entityDtoList = new List<T>();

            var result = new ResultTDto<T>()
            { Next = "" };

            var client = new HttpClient()
            {
                BaseAddress = new Uri("https://swapi.tech/api/")
            };

            string resource = (typeof(T).Name) switch
            {
                "PlanetInfoDto" => "planets/",
                "StarshipInfoDto" => "starships/",
                "VehicleInfoDto" => "vehicles/",
                "SpecieInfoDto" => "species/",
                "MovieInfoDto" => "films/",
                "CharacterInfoDto" => "people/",
                _ => ""
            };

            var option = new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true };

            while (result != null && result.Next != null)
            {
                var response = await client.GetAsync(resource);
                var responseContent = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<ResultTDto<T>>(responseContent, option);
                entityDtoList.AddRange(result!.Results);

                if (result.Next != null)
                {
                    resource = Regex.Match(result.Next, @"^(?:https:\/\/swapi.{1}tech\/api\/)(.+)$").Value;
                }
            }

            return entityDtoList;
        }

        public async Task<List<T>> GetEntityDtoInfoAsync<T>(List<T> entities)
        {
            var option = new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true };

            var entityDtoList = new List<T>();

            foreach (var entityDto in entities)
            {
                string? url = entityDto!.GetType()!.GetProperty("Url")!.GetValue(entityDto)!.ToString();

                var client = new HttpClient();

                var response = await client.GetAsync(url);
                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<Response<T>>(responseContent, option);

                if (result != null)
                {
                    entityDtoList.Add(result.Result.Properties);
                }
            }
            return entityDtoList;
        }

        public async Task<ICollection<T>> GetMovieDtoInfoAsync<T>()
        {
            var option = new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true };

            var entityDtoList = new List<T>();

            string? url = "https://swapi.tech/api/films";

            var client = new HttpClient();

            var response = await client.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<MovieResponse<T>>(responseContent, option);

            if (result != null)
            {
                foreach (var movie in result.Result)
                {
                    entityDtoList.Add(movie.Properties);
                }
            }

            return entityDtoList;
        }
    }
}
