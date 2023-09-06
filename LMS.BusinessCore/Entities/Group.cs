using System.ComponentModel.DataAnnotations;

namespace LMS.BusinessCore.Entities
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        public string GroupName { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]\d{3}[A-Z]$", ErrorMessage = "EAN format is not valid")]
        public string EAN { get; set; }

        public int CustomerId { get; set; }

        // Navigation property
        public Customer? Customer { get; set; }
        public List<GroupProduct>? GroupProducts { get; set; }
        public Group()
        {
            GroupProducts = new List<GroupProduct>();
        }
    }
}
