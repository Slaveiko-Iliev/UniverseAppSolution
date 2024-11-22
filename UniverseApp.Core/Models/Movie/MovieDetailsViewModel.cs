using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverseApp.Core.Models.Movie
{
    public class MovieDetailsViewModel : MovieFormModel
    {
        public int Id { get; set; }

        public ICollection<string> CharactersNames { get; set; } = new HashSet<string>();

        public ICollection<string> PlanetsNames { get; set; } = new HashSet<string>();

        public ICollection<string> StarshipsNames { get; set; } = new HashSet<string>();

        public ICollection<string> VehiclesNames { get; set; } = new HashSet<string>();

        public ICollection<string> SpeciesNames { get; set; } = new HashSet<string>();
    }
}
