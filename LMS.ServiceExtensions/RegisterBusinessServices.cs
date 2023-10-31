
using LMS.BusinessUseCases.CustomerUCs;
using LMS.BusinessUseCases.CustomerUCs.CustomerUCInterfaces;
using LMS.BusinessUseCases.GroupUCs;
using LMS.BusinessUseCases.GroupUCs.GroupUCInterfaces;
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

            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddTransient<ICreateGroupUC, CreateGroupUC>();
            services.AddTransient<IUpdateGroupNameUC, UpdateGroupNameUC>();
            services.AddTransient<IDeleteGroupWithProductsUC, DeleteGroupWithProductsUC>();
            services.AddTransient<IAddPurchasedQtysToGroupProductsUC, AddPurchasedQtysToGroupProductsUC>();

            

        }
    }
}
