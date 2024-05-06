using FluentValidation;
using TodoListApp.Entities.Dtos;

namespace TodoListApp.API.Services.Validators;

public class CreateTaskRequestValidator:AbstractValidator<CreateTaskRequest>
{
    public CreateTaskRequestValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty.");
        RuleFor(x => x.Status).NotEmpty().WithMessage("TaskStatu cannot be empty.");
    }
}