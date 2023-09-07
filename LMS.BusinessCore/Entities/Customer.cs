using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LMS.BusinessCore.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer name Is Required")]
        public string? CustomerName { get; set; }

        // Navigation properties should be initialized as empty lists.
        public List<PurchasedProduct> PurchasedProduct { get; set; } = new List<PurchasedProduct>();
        public List<Group> Groups { get; set; } = new List<Group>();
    }

}
