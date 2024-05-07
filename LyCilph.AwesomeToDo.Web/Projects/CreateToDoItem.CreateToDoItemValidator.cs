using FastEndpoints;
using FluentValidation;
using LyCilph.AwesomeToDo.Infrastructure.Data.Config;

namespace LyCilph.AwesomeToDo.Web.Projects;

public class CreateToDoItemValidator : Validator<CreateToDoItemRequest>
{
    public CreateToDoItemValidator()
    {
        RuleFor(x => x.ProjectId)
            .GreaterThanOrEqualTo(0);
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
        RuleFor(x => x.Description)
            .NotEmpty();
    }
}
