using CleanArchitecture.MVC.Services.Abstract;
using CleanArchitecture.MVC.ViewModels.Book;

namespace CleanArchitecture.MVC.Services.Contracts
{
    public interface IBooksService
    {
        Task<ApiResponse<List<ViewBookViewModel>>> GetBooks();
        Task<ApiResponse<ViewBookViewModel>> GetBook(int id);

        Task<ApiResponse<ViewBookViewModel>> CreateBook(CreateBookViewModel book);
        Task<ApiResponse>UpdateBook(UpdateBookViewModel book);
        Task<ApiResponse> DeleteBook(int bookId);
    }
}
