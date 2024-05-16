using System.ComponentModel.DataAnnotations;

namespace Unibank.MVC.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Fullname { get;set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
