using Application.Dto;
using FluentValidation;

namespace Web.Api.Validation.TaskValidator;

public class TaskValidator : AbstractValidator<TaskRequest>
{
    public TaskValidator()
    {
        RuleFor(prop => prop.Title)
            .NotEmpty().WithMessage("სათაური აუცილებელია")
            .MinimumLength(2).WithMessage("სათაური მინიმუმ 2 ასოსგან უნდა შედგებოდეს")
            .MaximumLength(200).WithMessage("სათაური არ უნდა აღემატებოდეს 200 სიმბოლოს");
        
        RuleFor(prop => prop.Description)
            .MaximumLength(1000).WithMessage("აღწერა არ უნდა აღემატებოდეს 1000 სიმბოლოს")
            .When(prop => !string.IsNullOrEmpty(prop.Description));
        
        RuleFor(prop => prop.Category)
            .IsInEnum().WithMessage("კატეგორია არასწორია");
        
        RuleFor(prop => prop.Priority)
            .IsInEnum().WithMessage("პრიორიტეტი არასწორია");
        
        RuleFor(prop => prop.DueTime)
            .NotEmpty().WithMessage("დასრულების თარიღი აუცილებელია")
            .GreaterThan(DateTime.UtcNow).WithMessage("დასრულების თარიღი მომავალში უნდა იყოს");
    }
}