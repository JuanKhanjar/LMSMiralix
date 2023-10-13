using LMS.BusinessCore.Entities;
using LMS.BusinessUseCases.PluginInterfaces;
using LMS.SqlServer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.SqlServer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbContextFactory<LMSDbContext> _dbContextFactory;

        public CustomerRepository(IDbContextFactory<LMSDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        // Load data to memeory then filter
        //public async Task<Customer?> GetCustomerWithGroupsAndProductsAsync(int customerId)
        //{
        //    using LMSDbContext _dbContext = _dbContextFactory.CreateDbContext();
        //    // Create a Stopwatch instance to measure the execution time
        //    Stopwatch stopwatch = new Stopwatch();
        //    stopwatch.Start();
        //    var customer = await _dbContext.Customers
        //        .Include(c => c.Groups)
        //        .ThenInclude(g => g.GroupProducts)
        //        .ThenInclude(gp => gp.PurchasedProduct)
        //        .FirstOrDefaultAsync(c => c.CustomerId == customerId);

        //    if (customer != null)
        //    {
        //        // Filter the GroupProducts based on the condition
        //        foreach (var group in customer.Groups)
        //        {
        //            group.GroupProducts = group.GroupProducts
        //                .Where(gp => gp.AddedQuantity > 0)
        //                .ToList();
        //        }
        //    }
        //    stopwatch.Stop();
        //    // Get the elapsed time
        //    TimeSpan elapsedTime = stopwatch.Elapsed;

        //    Console.WriteLine($"Method execution time: {elapsedTime}");
        //    return customer;
        //}

        /*
         *  However, if you expect large amounts of data, 
         *  consider using database queries to filter data before loading it into memory for better performance.
         */
        public async Task<Customer?> GetCustomerWithGroupsAndProductsAsync(int customerId)
        {
            using LMSDbContext _dbContext = _dbContextFactory.CreateDbContext();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Customer? customer = await _dbContext.Customers
                .Include(cg => cg.Groups)
                .ThenInclude(gp => gp.GroupProducts)
                .Include(cpp => cpp.PurchasedProducts)
                .Where(c => c.CustomerId == customerId)
                .Select(customer => new Customer
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    Groups = customer.Groups.Select(g => new Group
                    {
                        GroupId = g.GroupId,
                        GroupName = g.GroupName,
                        EAN = g.EAN,    
                        GroupProducts = g.GroupProducts
                            .Where(gp => gp.AddedQuantity > 0)
                            .ToList()
                    }).ToList()
                })
                .FirstOrDefaultAsync();
            stopwatch.Stop();
            // Get the elapsed time
            TimeSpan elapsedTime = stopwatch.Elapsed;

            Console.WriteLine($"Method execution time: {elapsedTime}");
            return customer;
        }

    }
}
