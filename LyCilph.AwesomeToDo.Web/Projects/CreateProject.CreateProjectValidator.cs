using FastEndpoints;
using FluentValidation;
using LyCilph.AwesomeToDo.Infrastructure.Data;

namespace LyCilph.AwesomeToDo.Web.Projects;

public class CreateProjectValidator : Validator<CreateProjectRequest>
{
    public CreateProjectValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MinimumLength(2)
            .MaximumLength(DataSchemaConstants.DEFAULT_NAME_LENGTH);
    }
}
