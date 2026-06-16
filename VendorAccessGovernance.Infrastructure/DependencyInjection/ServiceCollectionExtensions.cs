using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using VendorAccessGovernance.Application.Abstractions;
using VendorAccessGovernance.Application.Services;
using VendorAccessGovernance.Infrastructure.Persistence;
using VendorAccessGovernance.Infrastructure.Repositories;

namespace VendorAccessGovernance.Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<VendorAccessDbContext>(options =>

            options.UseSqlServer(configuration.GetConnectionString("DefeaultConnection")));

            services.AddScoped<IAccessRequestRepository, AccessRequestRepository>();
            services.AddScoped<IExternalWorkerRepository, ExternalWorkerRepository>();
            services.AddScoped<IVendorRepository, VendorRepository>();

            return services;
        }
    }
}
