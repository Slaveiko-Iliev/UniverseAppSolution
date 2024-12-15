using UniverseApp.Infrastructure.Data.DTOs;

namespace UniverseApp.Core.Models.Character
{
    public class CharacterDetailsViewModel : CharacterFormModel
    {
        public int Id { get; set; }

        public ICollection<KeyValuePair<string, EntityNameDto>> MoviesNames { get; set; } = new List<KeyValuePair<string, EntityNameDto>>();

        public ICollection<KeyValuePair<string, EntityNameDto>> SpeciesNames { get; set; } = new List<KeyValuePair<string, EntityNameDto>>();

        public ICollection<KeyValuePair<string, EntityNameDto>> VehiclesNames { get; set; } = new List<KeyValuePair<string, EntityNameDto>>();

        public ICollection<KeyValuePair<string, EntityNameDto>> StarshipsNames { get; set; } = new List<KeyValuePair<string, EntityNameDto>>();
    }
}
