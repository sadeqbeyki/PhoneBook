using System.ComponentModel.DataAnnotations;

namespace PhoneBook.EndPoints.Models.AAA
{
    public class PBLoginModel
    {
        [Required]
        [Display(Name = "User Name / Email ")]
        public string Name { get; set; }
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}
