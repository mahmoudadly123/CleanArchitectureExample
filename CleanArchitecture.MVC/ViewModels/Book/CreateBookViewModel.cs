using System.ComponentModel.DataAnnotations;
using CleanArchitecture.MVC.ViewModels.Abstract;

namespace CleanArchitecture.MVC.ViewModels.Book
{
    public class CreateBookViewModel: BaseViewModel
    {
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }

        [Required]
        public string? Category { get; set; }

        public bool IsActive { get; set; }
    }
}
