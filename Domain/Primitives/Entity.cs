namespace Domain.Primitives;

public abstract class Entity
{
    public DateTime AddedDate { get; set; }

    public DateTime LastModified { get; set; }
}
