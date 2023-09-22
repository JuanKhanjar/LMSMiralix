using LMS.BusinessCore.Entities;

namespace LMS.BusinessCore.ViewModels
{
    public class UpdateQuantityVM
    {
        public int CustomerId { get; set; }
        public int GroupId { get; set; }

        public int LicenseId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int GPChangeQuantity { get; set; }
        public int PPChangeQuantity { get; set; }
    }
}
