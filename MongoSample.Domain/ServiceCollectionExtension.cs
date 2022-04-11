using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MongoSample.Domain.Infrasructure;
using MongoSample.Domain.Infrasructure.Contracts;
using MongoSample.Domain.Infrasructure.Repositories;
using MongoSample.Infrastructure.Contracts;
using MongoSample.Infrastructure.Data;

namespace MongoSample.Domain
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(ServiceCollectionExtension).Assembly);
            services.AddMediatR(typeof(ServiceCollectionExtension).Assembly);
            services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtension).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient<IIndexManager, IndexManager>();
            return services;
        }
    }
}
