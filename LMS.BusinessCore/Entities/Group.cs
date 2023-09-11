using System.ComponentModel.DataAnnotations;

namespace LMS.BusinessCore.Entities
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required(ErrorMessage = "Group name is required")]
        public string GroupName { get; set; }

        //[Required(ErrorMessage = "EAN is required")]
        //[RegularExpression(@"^[A-Z]\d{3}[A-Z]$", ErrorMessage = "EAN format is not valid")]
        public string EAN { get; set; }

        public int CustomerId { get; set; }

        // Navigation property should be nullable
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<GroupProduct> GroupProducts { get; set; } = new List<GroupProduct>();
    }
}
