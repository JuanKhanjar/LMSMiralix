using LMS.BlazorApp.Areas.Identity;
using LMS.BlazorApp.Data;
using LMS.BusinessUseCases.CustomerUC;
using LMS.BusinessUseCases.CustomerUC.CustomerUCInterfaces;
using LMS.BusinessUseCases.GroupProductUC;
using LMS.BusinessUseCases.GroupProductUC.GroupProductUCInterfaces;
using LMS.BusinessUseCases.GroupUC;
using LMS.BusinessUseCases.GroupUC.GroupUCInterfaces;
using LMS.BusinessUseCases.PluginsInterfaces;
using LMS.BusinessUseCases.PurchasedProductsUC;
using LMS.BusinessUseCases.PurchasedProductsUC.PurchasedProductUCInterfaces;
using LMS.SqlServer.Data;
using LMS.SqlServer.Repositories;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using LMS.ServiceExtensions;

namespace LMS.BlazorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("LMSUserConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddDbContextFactory<LMSDbContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("LMSConnection")));
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            builder.Services.AddRegisterServices();
            //builder.Services.AddScoped<IGroupRepository, GroupRepository>();
            //builder.Services.AddTransient<ICreateGroupUC, CreateGroupUC>();
            //builder.Services.AddTransient<IGetGroupWithProductsUC, GetGroupWithProductsUC>();
            //builder.Services.AddTransient<IGetGroupsForCustomerUC, GetGroupsForCustomerUC>();


            //builder.Services.AddScoped<IPurchasedProductRepository, PurchasedProductRepository>();
            //builder.Services.AddTransient<IGetPurchasedProductsByCustomerIdUC, GetPurchasedProductsByCustomerIdUC>();

            //builder.Services.AddScoped<IGroupProductRepository, GroupProductRepository>();
            //builder.Services.AddTransient<IGetGroupProductsByGroupIdUC, GetGroupProductsByGroupIdUC>();

            //builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            //builder.Services.AddTransient<IGetCustomerWithGroupsAndProductsUC, GetCustomerWithGroupsAndProductsUC>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}