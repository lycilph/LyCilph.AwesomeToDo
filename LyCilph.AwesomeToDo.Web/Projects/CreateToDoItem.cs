using FastEndpoints;
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
        await SendNotFoundAsync(cancellationToken);

        //var command = new AddToDoItemCommand(request.ProjectId, request.ContributorId, request.Title, request.Description);
        //var result = await _mediator.Send(command);

        //if (result.Status == Ardalis.Result.ResultStatus.NotFound)
        //{
        //    await SendNotFoundAsync(cancellationToken);
        //    return;
        //}

        //if (result.IsSuccess)
        //{
        //     send route to project
        //    await SendCreatedAtAsync<GetById>(new { projectId = request.ProjectId }, "");
        //};
        // TODO: Handle other cases as necessary
    }
}
