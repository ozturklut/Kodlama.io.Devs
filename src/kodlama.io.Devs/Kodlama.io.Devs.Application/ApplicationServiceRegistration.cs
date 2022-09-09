using Core.Application.Pipelines.Validation;
using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assm);
            services.AddMediatR(assm);

            services.AddScoped<ProgrammingLanguageBusinessRules>();
            services.AddScoped<ProgrammingTechnologyBusinessRules>();

            services.AddValidatorsFromAssembly(assm);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));


            return services;
        }
    }
}
