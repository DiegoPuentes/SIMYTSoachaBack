using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IUxPService
    {
        Task<IEnumerable<UsersXPermissions>> GetAllUxPAsync();
        Task<UsersXPermissions> CreateUxPAsync(int id, int pid, bool isdeleted);
    }
    public class UxPService : IUxPService
    {
        private readonly IUxPRepository _repository;
        public UxPService(IUxPRepository uxPRepository)
        {
            _repository = uxPRepository;
        }

        public Task<UsersXPermissions> CreateUxPAsync(int id, int pid, bool isdeleted)
        {
           return _repository.CreateUxPAsync(id, pid, isdeleted);
        }

        public Task<IEnumerable<UsersXPermissions>> GetAllUxPAsync()
        {
            return _repository.GetAllUxPAsync();
        }
    }
}
