using CleanArchitecture.MVC.ViewModels.Abstract;

namespace CleanArchitecture.MVC.ViewModels.Book
{
    public class DeleteBookViewModel : BaseViewModel
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
