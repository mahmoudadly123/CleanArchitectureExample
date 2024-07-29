using System.ComponentModel.DataAnnotations;
using CleanArchitecture.MVC.ViewModels.Abstract;

namespace CleanArchitecture.MVC.ViewModels.Book
{
    public class UpdateBookViewModel:BaseViewModel
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }

        [Required]
        public string? Category { get; set; }
        public bool IsActive { get; set; }


    }
}
