using LMS.BusinessCore.Entities;

namespace LMS.BusinessCore.Extensions.GroupExtentionsMethods
{
    public static class GroupExtensions
    {
        public static int GetTotalQuantityForAgroup(this Group? group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            int totalQuantity = group.GroupProducts?.Sum(gp => gp.AddedQuantity) ?? 0;
            return totalQuantity;
        }

        public static decimal GetTotalPriceForAgroup(this Group? group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            decimal totalPrice = group.GroupProducts?
                .Sum(gp => gp.AddedQuantity * (gp.PurchasedProduct?.ProductPrice ?? 0)) ?? 0;
            return totalPrice;
        }

        public static int GetTotalQuantityForGroups(this IEnumerable<Group>? groups)
        {
            int totalQuantity = groups?.Sum(group => group.GetTotalQuantityForAgroup()) ?? 0;
            return totalQuantity;
        }

        public static decimal GetTotalPriceForGroups(this IEnumerable<Group>? groups)
        {
            decimal totalPrice = groups?.Sum(group => group.GetTotalPriceForAgroup()) ?? 0;
            return totalPrice;
        }
    }
}
