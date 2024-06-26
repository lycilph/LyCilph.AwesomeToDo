﻿using MediatR;

namespace LyCilph.AwesomeToDo.UseCases.Projects.AddToDoItem;

public record AddToDoItemCommand(int projectId, string Title, string Description) : IRequest<int> { }
