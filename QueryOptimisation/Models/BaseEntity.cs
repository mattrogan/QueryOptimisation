namespace QueryOptimisation.Models;

public abstract class BaseEntity
{
    public Guid UniqueId { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime DateCreated { get; set; } = DateTime.Now.Date;
}
