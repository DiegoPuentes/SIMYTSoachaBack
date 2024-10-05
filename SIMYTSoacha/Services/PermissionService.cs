using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IPermissionService
    {
        Task<IEnumerable<Permissions>> GetPermissionAsync();
        Task<Permissions> GetPermissionByIdAsync(int id);
        Task CreatePermissionAsync(Permissions permissions);
        Task UpdatePermissionAsync(Permissions permissions);
        Task SoftDeletePermissionAsync(int id);
    }
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _pRepository;
        public PermissionService(IPermissionRepository permissionRepository)
        {
            _pRepository = permissionRepository;
        }

        public Task CreatePermissionAsync(Permissions permissions)
        {
            return _pRepository.CreatePermissionAsync(permissions);
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
