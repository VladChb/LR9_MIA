using BookHubAPI.Models;
using BookHubAPI.Repository;

namespace BookHubAPI.Services
{
    public class AuthorService
    {
        private readonly IRepository<Author> _repository;

        public AuthorService(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public Task<List<Author>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Author?> GetByIdAsync(string id) => _repository.GetByIdAsync(id);
        public Task CreateAsync(Author author) => _repository.CreateAsync(author);
        public Task UpdateAsync(Author author) => _repository.UpdateAsync(author);
        public Task DeleteAsync(string id) => _repository.DeleteAsync(id);
    }
}
