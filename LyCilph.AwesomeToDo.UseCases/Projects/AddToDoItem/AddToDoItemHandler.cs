using LyCilph.AwesomeToDo.Core.ProjectAggregate;
using LyCilph.SharedKernel;

namespace LyCilph.AwesomeToDo.UseCases.Projects.AddToDoItem;

public class AddToDoItemHandler : ICommandHandler<AddToDoItemCommand, int>
{
    private readonly IRepository<Project> _repository;

    public AddToDoItemHandler(IRepository<Project> repository)
    {
        _repository = repository;
    }

    public async Task<int> Handle(AddToDoItemCommand request, CancellationToken cancellationToken)
    {
        // Get project it belongs to
        var project = await _repository.FirstOrDefault(p => p.Id == request.projectId);
        if (project == null)
        {
            return -1;
        }

        var item = new ToDoItem() { Title = request.Title, Description = request.Description };
        project.AddItem(item);

        await _repository.UpdateAsync(project, cancellationToken);

        return project.Id;
    }
}
