using BookHubAPI.Models;
using BookHubAPI.Repository;

namespace BookHubAPI.Services
{
    public class BookService
    {
        private readonly IRepository<Book> _repository;

        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public Task<List<Book>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Book?> GetByIdAsync(string id) => _repository.GetByIdAsync(id);
        public Task CreateAsync(Book book) => _repository.CreateAsync(book);
        public Task UpdateAsync(Book book) => _repository.UpdateAsync(book);
        public Task DeleteAsync(string id) => _repository.DeleteAsync(id);
    }
}
