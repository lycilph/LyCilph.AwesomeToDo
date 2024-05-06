namespace LyCilph.SharedKernel;

public abstract class EntityBase
{
    public int Id { get; set; }
}

public abstract class EntityBase<TId> where TId : struct, IEquatable<TId>
{
    public TId Id { get; set; }
}
