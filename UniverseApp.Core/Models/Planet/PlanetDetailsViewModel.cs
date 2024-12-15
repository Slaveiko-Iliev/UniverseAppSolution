﻿using UniverseApp.Infrastructure.Data.DTOs;

namespace UniverseApp.Core.Models.Planet
{
    public class PlanetDetailsViewModel : PlanetFormModel
    {
        public int Id { get; set; }

        public ICollection<KeyValuePair<string, EntityNameDto>> CharactersNames { get; set; } = new List<KeyValuePair<string, EntityNameDto>>();

        public ICollection<KeyValuePair<string, EntityNameDto>> SpeciesNames { get; set; } = new List<KeyValuePair<string, EntityNameDto>>();

        public ICollection<KeyValuePair<string, EntityNameDto>> MoviesNames { get; set; } = new List<KeyValuePair<string, EntityNameDto>>();
    }
}
