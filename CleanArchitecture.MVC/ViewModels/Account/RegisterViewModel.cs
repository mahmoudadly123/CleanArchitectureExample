using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CleanArchitecture.MVC.ViewModels.Abstract;


namespace CleanArchitecture.MVC.ViewModels.Account
{
    public class RegisterViewModel : BaseViewModel
    {
        [Required]
        [DisplayName("UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string UserPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare(nameof(UserPassword),ErrorMessage = "Not Matched Password")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string UserEmail { get; set; }

    }
}
