using BookHubAPI.Models;
using BookHubAPI.Repository;

namespace BookHubAPI.Services
{
    public class MemberService
    {
        private readonly IRepository<Member> _repository;

        public MemberService(IRepository<Member> repository)
        {
            _repository = repository;
        }

        public Task<List<Member>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Member?> GetByIdAsync(string id) => _repository.GetByIdAsync(id);
        public Task CreateAsync(Member member) => _repository.CreateAsync(member);
        public Task UpdateAsync(Member member) => _repository.UpdateAsync(member);
        public Task DeleteAsync(string id) => _repository.DeleteAsync(id);
    }
}
