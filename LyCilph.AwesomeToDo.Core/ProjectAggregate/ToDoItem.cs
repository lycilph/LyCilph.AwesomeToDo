using System.Diagnostics;

namespace LyCilph.AwesomeToDo.Core.ProjectAggregate;

[DebuggerDisplay("Title = {Title}, IsDone = {IsDone}")]
public class ToDoItem : EntityBase
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsDone { get; private set; }

    public override string ToString()
    {
        string status = IsDone ? "Done!" : "Not done.";
        return $"{Id}: Status: {status} - {Title} - {Description}";
    }
}
