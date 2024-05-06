using FluentValidation;
using TodoListApp.Entities.Dtos;

namespace TodoListApp.API.Services.Validators;

public class UpdateTaskRequestValidator:AbstractValidator<UpdateTaskRequest>
{
    public UpdateTaskRequestValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty");
        RuleFor(x => x.Status).NotEmpty().WithMessage("Status cannot be empty");
    } 
}