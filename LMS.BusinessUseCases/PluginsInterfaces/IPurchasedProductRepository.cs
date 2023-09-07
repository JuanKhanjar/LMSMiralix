using LMS.BusinessCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BusinessUseCases.PluginsInterfaces
{
    public interface IPurchasedProductRepository
    {
        /// <summary>
        /// This Method Will Return A list of Products that a spesific Customer had purchased
        /// </summary>
        /// <param name="customerId">int</param>
        /// <returns>List of objects of type Product </returns>
        Task<IEnumerable<PurchasedProduct>> GetPurchasedProductsByCustomerIdAsync(int customerId);
    }
}
