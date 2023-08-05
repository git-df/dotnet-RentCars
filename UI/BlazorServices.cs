using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Reflection;
using UI.Interfaces.Security;
using UI.Interfaces;
using UI.Services.Security;
using UI.Services;

namespace UI
{
    public static class BlazorServices
    {
        public static IServiceCollection AddBlazorServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddBlazoredLocalStorage();

            services.AddAuthorizationCore();

            services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri("clienturl")
            });

            services.AddHttpClient<IClient, Client>
                (client => client.BaseAddress = new Uri("apiurl"));

            services.AddScoped<IAddBearerTokenService, AddBearerTokenService>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICarModelService, CarModelService>();
            services.AddScoped<ICarAttributeService, CarAttributeService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IRentService, RentService>();
            services.AddScoped<IPaymentService, PaymentService>();

            return services;
        }
    }
}
