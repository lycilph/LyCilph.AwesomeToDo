using LyCilph.AwesomeToDo.Core.ProjectAggregate;
using LyCilph.AwesomeToDo.Infrastructure.Data;

namespace LyCilph.AwesomeToDo.Web;

public static class SeedData
{
    public static Project seedProject = new Project("Seed Project");
    public static ToDoItem seedToDoItem1 = new ToDoItem() { Title = "Todo item 1", Description = "Do stuff" };
    public static ToDoItem seedToDoItem2 = new ToDoItem() { Title = "Todo item 2", Description = "Do more stuff" };
    public static ToDoItem seedToDoItem3 = new ToDoItem() { Title = "Todo item 3", Description = "Do even more stuff" };

    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = serviceProvider.GetRequiredService<AppDbContext>())
        {
            if (context.Projects.Any())
            {
                return;
            }

            PopulateTestData(context);
        }
    }

    private static void PopulateTestData(AppDbContext context)
    {
        foreach (var item in context.Projects)
        {
            context.Remove(item);
        }
        foreach (var item in context.ToDoItems)
        {
            context.Remove(item);
        }
        context.SaveChanges();

        seedProject.AddItem(seedToDoItem1);
        seedProject.AddItem(seedToDoItem2);
        seedProject.AddItem(seedToDoItem3);
        context.Projects.Add(seedProject);
        context.SaveChanges();
    }
}
