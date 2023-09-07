using System.ComponentModel.DataAnnotations;

namespace LMS.BusinessCore.Entities
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required(ErrorMessage = "Group name is required")]
        public string? GroupName { get; set; }

        [Required(ErrorMessage = "EAN is required")]
        [RegularExpression(@"^[A-Z]\d{3}[A-Z]$", ErrorMessage = "EAN format is not valid")]
        public string? EAN { get; set; }

        public int CustomerId { get; set; }

        // Navigation property
        public Customer Customer { get; set; } = new Customer();
        public List<GroupProduct> GroupProducts { get; set; } = new List<GroupProduct>();
    }
}
