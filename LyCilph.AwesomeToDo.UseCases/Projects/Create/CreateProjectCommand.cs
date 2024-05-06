using LyCilph.SharedKernel;

namespace LyCilph.AwesomeToDo.UseCases.Projects.Create;

public record CreateProjectCommand(string Name) : ICommand<int> {}
