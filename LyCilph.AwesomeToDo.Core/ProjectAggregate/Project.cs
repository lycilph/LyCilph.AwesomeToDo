using LyCilph.SharedKernel;

namespace LyCilph.AwesomeToDo.Core.ProjectAggregate;

public class Project : EntityBase, IAggregateRoot
{
    public string Name { get; private set; }

    
    private readonly List<ToDoItem> _items = [];
    public IEnumerable<ToDoItem> Items => _items.AsReadOnly();

    public ProjectStatus Status => _items.All(i => i.IsDone) ? ProjectStatus.Complete : ProjectStatus.InProgress;

    public Project(string name)
    {
        Name = name ?? "Anonymous";
    }

    public void AddItem(ToDoItem item)
    {
        _items.Add(item);
        // Send event here
    }
}
