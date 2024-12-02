using System.ComponentModel.DataAnnotations;

namespace UniverseApp.Infrastructure.Data.DTOs
{
    public class ResultTDto<T>
    {
        [Required]
        public int Count { get; set; }

        [Required]
        public string Next { get; set; } = string.Empty;

        [Required]
        public string Previous { get; set; } = string.Empty;

        public ICollection<T> Results { get; set; } = new List<T>();
    }
}
