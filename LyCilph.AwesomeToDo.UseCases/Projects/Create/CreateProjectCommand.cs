using MediatR;

namespace LyCilph.AwesomeToDo.UseCases.Projects.Create;

public record CreateProjectCommand(string Name) : IRequest<int> { }
