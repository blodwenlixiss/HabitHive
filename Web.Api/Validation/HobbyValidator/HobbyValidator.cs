using Application.Dto;
using Domain.Enum;
using FluentValidation;

namespace Web.Api.Validation.HobbyValidator;

public class HobbyValidator : AbstractValidator<HobbyRequest>
{
    public HobbyValidator()
    {
        RuleFor(prop => prop.Title)
            .NotEmpty().WithMessage("სათაური აუცილებელია")
            .MinimumLength(2).WithMessage("სათაური მინიმუმ 2 ასოსგან უნდა შედგებოდეს")
            .MaximumLength(100).WithMessage("სათაური არ უნდა აღემატებოდეს 100 სიმბოლოს");

        RuleFor(prop => prop.Description)
            .MaximumLength(500).WithMessage("აღწერა არ უნდა აღემატებოდეს 500 სიმბოლოს")
            .When(prop => !string.IsNullOrEmpty(prop.Description));

        RuleFor(prop => prop.Frequency)
            .IsInEnum().WithMessage("სიხშირე არასწორია");
    }
}