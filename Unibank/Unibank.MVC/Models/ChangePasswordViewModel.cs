using System.ComponentModel.DataAnnotations;

namespace Unibank.MVC.Models
{
    public class ChangePasswordViewModel
    {
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password),Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set;}
    }
}
