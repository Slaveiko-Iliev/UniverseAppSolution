namespace UniverseApp.Infrastructure.Common
{
    public interface IEntity
    {
        bool IsDeleted { get; set; }
    }
}
