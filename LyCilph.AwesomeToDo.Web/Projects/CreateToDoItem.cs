using FastEndpoints;
using LyCilph.AwesomeToDo.UseCases.Projects.AddToDoItem;
using MediatR;

namespace LyCilph.AwesomeToDo.Web.Projects;

public class CreateToDoItem : Endpoint<CreateToDoItemRequest>
{
    private readonly IMediator _mediator;

    public CreateToDoItem(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Post(CreateToDoItemRequest.Route);
        AllowAnonymous();
        Summary(s =>
        {
            s.ExampleRequest = new CreateToDoItemRequest
            {
                ProjectId = 1,
                Title = "Title",
                Description = "Description"
            };
        });
    }

    public override async Task HandleAsync(CreateToDoItemRequest request, CancellationToken cancellationToken)
    {
        var command = new AddToDoItemCommand(request.ProjectId, request.Title, request.Description);
        var result = await _mediator.Send(command, cancellationToken);

        if (result == -1)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        if (result >= 0) 
        {
            await SendOkAsync(cancellationToken);
        }
    }
}
