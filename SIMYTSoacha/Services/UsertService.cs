using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IUsertService
    {
        Task<IEnumerable<UsersTypes>> GetAllUserAsync();
        Task<UsersTypes> GetUserByIdAsync(int id);
        Task CreateUserAsync(UsersTypes types);
        Task UpdateUserAsync(UsersTypes types);
        Task SoftDeleteUserAsync(int id);
    }
    public class UsertService : IUsertService
    {
        private readonly IUsertRepository _repository;
        public UsertService(IUsertRepository usertRepository)
        {
            _repository = usertRepository;
        }

        public Task CreateUserAsync(UsersTypes types)
        {
            return _repository.CreateUserAsync(types);
        }

        public Task<IEnumerable<UsersTypes>> GetAllUserAsync()
        {
            return _repository.GetAllUserAsync();
        }

        public Task<UsersTypes> GetUserByIdAsync(int id)
        {
            return _repository.GetUserByIdAsync(id);
        }

        public Task SoftDeleteUserAsync(int id)
        {
            return _repository.SoftDeleteUserAsync(id); 
        }

        public Task UpdateUserAsync(UsersTypes types)
        {
            return _repository.UpdateUserAsync(types);  
        }
    }
}
