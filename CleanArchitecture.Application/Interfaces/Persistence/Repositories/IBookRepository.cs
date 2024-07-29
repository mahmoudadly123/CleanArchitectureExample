using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Interfaces.Persistence.Repositories
{
    public interface IBookRepository : IGenericRepository<Book, int>
    {
        Task<List<Book>> GetActiveBooks();
        Task<List<Book>> GetDeActiveBooks();
        Task<List<Book>> GetBooksInsideCategory(string category);
    }
}
