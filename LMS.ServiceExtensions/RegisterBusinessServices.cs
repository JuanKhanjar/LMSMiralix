
using LMS.BusinessUseCases.CustomerUCs;
using LMS.BusinessUseCases.CustomerUCs.CustomerUCInterfaces;
using LMS.BusinessUseCases.PluginInterfaces;
using LMS.BusinessUseCases.PurchasedProductsUCs;
using LMS.BusinessUseCases.PurchasedProductsUCs.PurchasedProductsUCsInterfaces;
using LMS.SqlServer.Data;
using LMS.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LMS.ServiceExtensions
{
    public static class RegisterBusinessServices
    {
        public static void AddRegisterServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContextFactory<LMSDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("LMSConnection")));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IGetCustomerWithGroupsAndProductsUC, GetCustomerWithGroupsAndProductsUC>();

            services.AddScoped<IPurchasedProductRepository, PurchasedProductRepository>();
            services.AddTransient<IGetPurchasedProductsByCustomerIdUC, GetPurchasedProductsByCustomerIdUC>();
        }
    }
}
