using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IUsertRepository
    {
        Task<IEnumerable<UsersTypes>> GetAllUserAsync();
        Task<UsersTypes> GetUserByIdAsync(int id);
        Task CreateUserAsync(UsersTypes types);
        Task UpdateUserAsync(UsersTypes types);
        Task SoftDeleteUserAsync(int id);
    }
    public class UsertRepository : IUsertRepository
    {
        private readonly SimytDbContext context;
        public UsertRepository(SimytDbContext _context)
        {
            context = _context;
        }

        public async Task CreateUserAsync(UsersTypes types)
        {
            context.UsersTypes.Add(types);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UsersTypes>> GetAllUserAsync()
        {
            return await context.UsersTypes.
                Where(s => !s.Isdeleted)
                .ToListAsync();
        }

        public async Task<UsersTypes> GetUserByIdAsync(int id)
        {
            return await context.UsersTypes.
                FirstOrDefaultAsync(s => s.UtypesId == id && !s.Isdeleted);
        }

        public async Task SoftDeleteUserAsync(int id)
        {
            var user = await context.UsersTypes.FindAsync(id);
            if (user != null)
            {
                user.Isdeleted = true;
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateUserAsync(UsersTypes types)
        {
            context.UsersTypes.Update(types);
            await context.SaveChangesAsync();
        }
    }
}
