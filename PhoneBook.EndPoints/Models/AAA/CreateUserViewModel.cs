using System.ComponentModel.DataAnnotations;

namespace PhoneBook.EndPoints.Models.AAA
{
    public class CreateUserViewModel
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
    public class UpdateUserViewModel : CreateUserViewModel
    {
        //[Required]
        //[MaxLength(50)]
        //public string UserName { get; set; }
        //[Required]
        //[MaxLength(100)]
        //public string Email { get; set; }
        public string? Id { get; set; }
    }
}
