namespace LyCilph.AwesomeToDo.Core;

public abstract class EntityBase
{
    public int Id { get; set; }
}

public abstract class EntityBase<TId> where TId : struct, IEquatable<TId>
{
    public TId Id { get; set; }
}
