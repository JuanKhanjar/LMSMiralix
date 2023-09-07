using LMS.BusinessUseCases.CustomerUC;
using LMS.BusinessUseCases.CustomerUC.CustomerUCInterfaces;
using LMS.BusinessUseCases.GroupProductUC;
using LMS.BusinessUseCases.GroupProductUC.GroupProductUCInterfaces;
using LMS.BusinessUseCases.GroupUC;
using LMS.BusinessUseCases.GroupUC.GroupUCInterfaces;
using LMS.BusinessUseCases.PluginsInterfaces;
using LMS.BusinessUseCases.PurchasedProductsUC;
using LMS.BusinessUseCases.PurchasedProductsUC.PurchasedProductUCInterfaces;
using LMS.SqlServer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.ServiceExtensions
{
    public static class RegisterBusinessServices
    {
        public static void AddRegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddTransient<ICreateGroupUC, CreateGroupUC>();
            services.AddTransient<IGetGroupWithProductsUC, GetGroupWithProductsUC>();
            services.AddTransient<IGetGroupsForCustomerUC, GetGroupsForCustomerUC>();

            services.AddScoped<IPurchasedProductRepository, PurchasedProductRepository>();
            services.AddTransient<IGetPurchasedProductsByCustomerIdUC, GetPurchasedProductsByCustomerIdUC>();

            services.AddScoped<IGroupProductRepository, GroupProductRepository>();
            services.AddTransient<IGetGroupProductsByGroupIdUC, GetGroupProductsByGroupIdUC>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IGetCustomerWithGroupsAndProductsUC, GetCustomerWithGroupsAndProductsUC>();

        }
    }
}
