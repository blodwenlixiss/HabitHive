using FluentValidation;
using FluentValidation.AspNetCore;
using Web.Api.Validation.HobbyValidator;

namespace Web.Api.Configurations;

public static class ValidatorConfigurations
{
    /// <summary>
    /// Adds validator configurations to the service collection.
    /// </summary>
    /// <returns></returns>
    public static IServiceCollection AddValidatorConfigurations(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();

        services.AddValidatorsFromAssemblyContaining<HobbyValidator>();

        return services;
    }
}