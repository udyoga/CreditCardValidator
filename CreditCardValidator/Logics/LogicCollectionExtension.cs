using CreditCardValidator.Logics.Implementation;
using CreditCardValidator.Logics.Interface;
using CreditCardValidator.Models;
using CreditCardValidator.Validators;
using FluentValidation;

namespace CreditCardValidator.Logics
{
    public static class LogicCollectionExtension
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddTransient<IValidator<CardRequet>, CardInputValidator>();
            services.AddSingleton<ICardValidateLogic, CardValidateLogic>();
            return services;
        }
    }
}
