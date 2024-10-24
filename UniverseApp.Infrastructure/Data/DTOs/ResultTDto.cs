using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniverseApp.Infrastructure.Data.DTOs
{
    internal class ResultTDto<T>
    {
        [Required]
        internal int Count { get; set; }

        [Required]
        internal string Next { get; set; } = string.Empty;

        [Required]
        internal string Previous { get; set; } = string.Empty;

        internal ICollection<T> Results { get; set; } = new List<T>();
    }
}
