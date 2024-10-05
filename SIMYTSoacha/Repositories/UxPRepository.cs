using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IUxPRepository
    {
        Task<IEnumerable<UsersXPermissions>> GetAllUxPAsync();
        Task<UsersXPermissions> CreateUxPAsync(int id, int pid, bool isdeleted);
    }
    public class UxPRepository : IUxPRepository
    {
        private readonly SimytDbContext context;
        public UxPRepository(SimytDbContext simytDbContext)
        {
            context = simytDbContext;
        }

        public async Task<UsersXPermissions> CreateUxPAsync(int id, int pid, bool isdeleted)
        {
            UsersXPermissions user = new UsersXPermissions
            {
                UtypeId = id,
                UsersType = null,
                PermissionId = pid,
                Permissions = null,
                Isdeleted = isdeleted
            };
            context.UsersXPermissions.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<UsersXPermissions>> GetAllUxPAsync()
        {
            return await context.UsersXPermissions.
                Where(s => !s.Isdeleted)
                .ToListAsync();
        }
    }
}
