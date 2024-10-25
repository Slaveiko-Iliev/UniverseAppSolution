using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverseApp.Infrastructure.Data.Models
{
    public class Starship
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Comment("Starship Identifier")]
        public int Id { get; set; }

        public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
