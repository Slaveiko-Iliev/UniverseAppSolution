namespace UniverseApp.Infrastructure.Models
{
    public interface IEntity
    {
        bool IsDeleted { get; set; }
    }
}
