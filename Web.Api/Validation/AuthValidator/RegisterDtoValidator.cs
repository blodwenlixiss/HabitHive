using FluentValidation;
using RegisterRequest = Application.Dto.RegisterRequest;

namespace Web.Api.Validation.AuthValidator;

public class RegisterDtoValidator : AbstractValidator<RegisterRequest>
{
    /// <summary>
    /// Validated RegisterDto Fields
    /// </summary>
    public RegisterDtoValidator()
    {
        RuleFor(prop => prop.FirstName)
            .Matches("^[a-zA-Zა-ჰ]+$").WithMessage("სახელი უნდა შეიცავდეს მხოლოდ ასოებს")
            .Length(2, 25).WithMessage("სახელი უნდა შეიცავდეს მინიმუმ 2 და მაქსიმუმ 25 სიმბოლოს")
            .NotNull().WithMessage("სახელი აუცილებელია");

        RuleFor(prop => prop.LastName)
            .Matches("^[a-zA-Zა-ჰ]+$").WithMessage("გვარი უნდა შეიცავდეს მხოლოდ ასოებს")
            .Length(2, 25).WithMessage("გვარი უნდა შეიცავდეს მინიმუმ 2 და მაქსიმუმ 25 სიმბოლოს")
            .NotNull().WithMessage("გვარი აუცილებელია");

        RuleFor(prop => prop.Email)
            .EmailAddress().WithMessage("ელ-ფოსტის ფორმატი არასწორია")
            .Length(5, 50).WithMessage("ელ-ფოსტა უნდა შეიცავდეს მინიმუმ 5 და მაქსიმუმ 50 სიმბოლოს")
            .NotNull().WithMessage("ელ-ფოსტა აუცილებელია");

        RuleFor(prop => prop.Password)
            .MinimumLength(8).WithMessage("პაროლი უნდა შეიცავდეს მინიმუმ 8 სიმბოლოს")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
            .WithMessage("პაროლი უნდა შეიცავდეს ერთ დიდ ასოს, ერთ პატარა ასოს, ერთ ციფრს და ერთ სპეციალურ სიმბოლოს")
            .NotNull().WithMessage("პაროლი აუცილებელია");
    }
}