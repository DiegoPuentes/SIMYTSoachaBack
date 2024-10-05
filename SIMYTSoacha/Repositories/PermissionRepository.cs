using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permissions>> GetPermissionAsync();
        Task<Permissions> GetPermissionByIdAsync(int id);
        Task CreatePermissionAsync(Permissions permissions);
        Task UpdatePermissionAsync(Permissions permissions);
        Task SoftDeletePermissionAsync(int id);
    }
    public class PermissionRepository : IPermissionRepository
    {
        private readonly SimytDbContext _context;
        public PermissionRepository(SimytDbContext simytDbContext)
        {
             _context = simytDbContext;
        }

        public async Task CreatePermissionAsync(Permissions permissions)
        {
            _context.Permissions.Add(permissions);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Permissions>> GetPermissionAsync()
        {
            return await _context.Permissions
                .Where(s => !s.Isdeleted)
                .ToListAsync();
        }

        public async Task<Permissions> GetPermissionByIdAsync(int id)
        {
            return await _context.Permissions
                .FirstOrDefaultAsync(s => s.Pid == id && !s.Isdeleted);
        }

        public async Task SoftDeletePermissionAsync(int id)
        {
            var per = await _context.Permissions.FindAsync(id);
            if (per != null)
            {
                per.Isdeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePermissionAsync(Permissions permissions)
        {
            _context.Permissions.Update(permissions);
            _context.SaveChangesAsync();
        }
    }
}
