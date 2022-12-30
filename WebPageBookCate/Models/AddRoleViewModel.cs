using System.ComponentModel.DataAnnotations;

namespace WebPageBookCate.Models
{
    public class AddRoleViewModel
    {
            [Required]
            [Display(Name = "Role")]
            public string RoleName { get; set; }
        
    }
}