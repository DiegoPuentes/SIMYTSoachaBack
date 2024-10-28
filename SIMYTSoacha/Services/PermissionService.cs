using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permissions>> GetPermissionAsync();
        Task<Permissions> GetPermissionByIdAsync(int id);
        Task<bool> CreatePermissionAsync(Permissions permissions);
        Task UpdatePermissionAsync(Permissions permissions);
        Task SoftDeletePermissionAsync(int id);
    }
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _pRepository;
        private readonly IPeopleService _peopleService;
        private readonly IHttpContextAccessor _contextAccessor;
        public PermissionService(IPermissionRepository permissionRepository,
            IPeopleService peopleService, IHttpContextAccessor contextAccessor)
        {
            _pRepository = permissionRepository;
            _peopleService = peopleService;
            _contextAccessor = contextAccessor;
        }

        public async Task<bool> CreatePermissionAsync(Permissions permissions)
        {
            int? userType = _contextAccessor.HttpContext.Session.GetInt32("UserTypeId");
            if (userType != null)
            {
                if (await _peopleService.PermissionAsync(userType.Value, 1))
                {
                    await _pRepository.CreatePermissionAsync(permissions);
                    return true;
                }
                return false;
            }
            return false;
        }

        public Task<IEnumerable<Permissions>> GetPermissionAsync()
        {
            return _pRepository.GetPermissionAsync();
        }

        public Task<Permissions> GetPermissionByIdAsync(int id)
        {
            return _pRepository.GetPermissionByIdAsync(id);
        }

        public Task SoftDeletePermissionAsync(int id)
        {
            return _pRepository.SoftDeletePermissionAsync(id);
        }

        public Task UpdatePermissionAsync(Permissions permissions)
        {
            return _pRepository.UpdatePermissionAsync(permissions);
        }
    }
}
