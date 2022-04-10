using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoSample.Domain
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceCollectionExtension).Assembly);
            services.AddMediatR(typeof(ServiceCollectionExtension).Assembly);
            return services;
        }
    }
}
