using LMS.BusinessCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BusinessCore.Extensions.GroupExtentionsMethods
{
    public static class GroupExtensions
    {
        public static int GetTotalQuantity(this Group group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            int totalQuantity = group.GroupProducts.Sum(gp => gp.AddedQuantity);
            return totalQuantity;
        }

        public static decimal GetTotalPrice(this Group group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            decimal totalPrice = group.GroupProducts.Sum(gp =>
                gp.AddedQuantity * gp.Product.ProductPrice);
            return totalPrice;
        }
        public static int GetTotalQuantity(this List<Group> groups)
        {
            int totalQuantity = groups.Sum(group => group.GetTotalQuantity());
            return totalQuantity;
        }

        public static decimal GetTotalPrice(this List<Group> groups)
        {
            decimal totalPrice = groups.Sum(group => group.GetTotalPrice());
            return totalPrice;
        }
    }

}
