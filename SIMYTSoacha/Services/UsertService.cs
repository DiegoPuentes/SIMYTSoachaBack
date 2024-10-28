using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IUsertService
    {
        Task<IEnumerable<UsersTypes>> GetAllUserAsync();
        Task<UsersTypes> GetUserByIdAsync(int id);
        Task<bool> CreateUserAsync(UsersTypes types);
        Task UpdateUserAsync(UsersTypes types);
        Task SoftDeleteUserAsync(int id);
    }
    public class UsertService : IUsertService
    {
        private readonly IUsertRepository _repository;
        private readonly IPeopleService _peopleService;
        private readonly IHttpContextAccessor _contextAccessor;
        public UsertService(IUsertRepository usertRepository, IPeopleService peopleService,
            IHttpContextAccessor httpContextAccessor)
        {
            _repository = usertRepository;
            _peopleService = peopleService;
            _contextAccessor = httpContextAccessor;
        }

        public async Task<bool> CreateUserAsync(UsersTypes types)
        {
            int? userType = _contextAccessor.HttpContext.Session.GetInt32("UserTypeId");
            if (userType != null)
            {
                if (await _peopleService.PermissionAsync(userType.Value, 1))
                {
                    await _repository.CreateUserAsync(types);
                    return true;
                }
                return false;
            }
            return false;
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
