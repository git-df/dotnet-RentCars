using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceInstalation
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RentCarsDbContext>(options =>
                options.UseSqlServer(configuration.
                GetConnectionString("RentCarsConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
            services.AddScoped<IUserAppRepository, UserAppRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IUserEmployeeRepository, UserEmployeeRepository>();
            services.AddScoped<IUserEmployee2BranchRepository, UserEmployee2BranchRepository>();
            services.AddScoped<IUserInfoRepository, UserInfoRepository>();
            services.AddScoped<ICarModelRepository, CarModelRepository>();
            services.AddScoped<ICarAttribureRepositoy, CarAttribureRepositoy>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IRentRepository, RentRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            return services;
        }
    }
}
