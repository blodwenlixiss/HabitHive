using Application.Dto;
using FluentValidation;

namespace Web.Api.Validation.AuthValidator;

public class LoginDtoValidator : AbstractValidator<AuthRequest>
{

    public LoginDtoValidator()
    {
        RuleFor(prop => prop.Email)
            .NotNull().WithMessage("ელ-ფოსტა აუცილებელია")
            .EmailAddress().WithMessage("ელ-ფოსტის ფორმატი არ არის სწორი")
            .Matches(@"^[\x00-\x7F]+$").WithMessage("მეილი უნდა შეიცავდეს მხოლოდ ინგლისურ სიმბოლოებს.");
        
        RuleFor(prop => prop.Password)
            .NotNull().WithMessage("პაროლი აუცილებელია.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
            .WithMessage("პაროლი უნდა შეიცავდეს ერთ დიდ ასოს, ერთ პატარა ასოს, ერთ ციფრს და ერთ სპეციალურ სიმბოლოს.")
            .Matches(@"^[\x00-\x7F]+$").WithMessage("პაროლი უნდა შეიცავდეს მხოლოდ ინგლისურ სიმბოლოებს.");
    }
}