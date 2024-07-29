using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CleanArchitecture.MVC.ViewModels.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.MVC.ViewModels.Account
{
    public class LoginViewModel: BaseViewModel
    {
        [Required]
        [DisplayName("UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string UserPassword { get; set; }

        [Required]
        [DisplayName("Security Stamp")]
        public string SecurityStamp { get; set; } = "123";

        [HiddenInput]
        public string ReturnUrl { get; set; }
    }
}
