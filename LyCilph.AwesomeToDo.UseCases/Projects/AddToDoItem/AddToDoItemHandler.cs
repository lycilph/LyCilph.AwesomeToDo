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

    public Task<int> Handle(AddToDoItemCommand request, CancellationToken cancellationToken)
    {
        
    }
}
