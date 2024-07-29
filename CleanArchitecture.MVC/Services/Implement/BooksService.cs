using AutoMapper;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.MVC.Services.Abstract;
using CleanArchitecture.MVC.Services.Contracts;
using CleanArchitecture.MVC.ViewModels.Book;

namespace CleanArchitecture.MVC.Services.Implement
{
    public class BooksService:ApiService,IBooksService
    {
        public BooksService(IMapper mapper, IApiClient apiClient, ILocalStorageService localStorage) : base(mapper, apiClient, localStorage) { }

        public async Task<ApiResponse<List<ViewBookViewModel>>> GetBooks()
        {
            return  await GetAsync<List<ViewBookDto>, List<ViewBookViewModel>>("book");
        }

        public async Task<ApiResponse<ViewBookViewModel>> GetBook(int id)
        {
            return await GetAsync<ViewBookDto, ViewBookViewModel>($"book/{id}");
        }

        public async Task<ApiResponse<ViewBookViewModel>> CreateBook(CreateBookViewModel book)
        {
            return await PostAsync<ViewBookDto, ViewBookViewModel>("book", book);
        }

        public async Task<ApiResponse> UpdateBook(UpdateBookViewModel book)
        {
            var result = await PutAsync<ViewBookDto, ViewBookViewModel>($"book/{book.Id}", book);

            return new ApiResponse(result.IsSuccess,result.Message, result.ValidationErrors);


        }

        public async Task<ApiResponse> DeleteBook(int bookId)
        {
            var result = await DeleteAsync<ViewBookDto, ViewBookViewModel>($"book/{bookId}");

            return new ApiResponse(result.IsSuccess, result.Message, result.ValidationErrors);

        }
    }
}
