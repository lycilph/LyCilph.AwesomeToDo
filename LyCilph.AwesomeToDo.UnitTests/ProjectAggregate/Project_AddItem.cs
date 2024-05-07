using LyCilph.AwesomeToDo.Core.ProjectAggregate;

namespace LyCilph.AwesomeToDo.UnitTests.ProjectAggregate;

public class Project_AddItem
{
    private Project _testProject = new Project("Test Project");

    [Fact]
    public void AddsItemToItems()
    {
        var item = new ToDoItem { Title = "New item", Description = "Test description" };
        _testProject.AddItem(item);

        Assert.Contains(item, _testProject.Items);
    }

    [Fact]
    public void ThrowsExceptionGivenNullItem()
    {
        var action = () => _testProject.AddItem(null!);

        var ex = Assert.Throws<ArgumentNullException>(action);
        Assert.Equal("item", ex.ParamName);
    }
}