using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repository
{
    public interface IPeopleRepository
    {
        Task<IEnumerable<People>> GetAllPeopleAsync();

        Task<People> GetPeopleByIdAsync(int id);

        Task CreatePeopleAsync(People subject);

        Task UpdatePeopleAsync(People subject);

        Task SoftDeletePeopleAsync(int id);
        public class PeopleRepository : IPeopleRepository
        {
            private readonly SimytDbContext _context;
            public PeopleRepository(SimytDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<People>> GetAllPeopleAsync()
            {

                return await _context.peoples
                      .Where(s => !s.IsDeleted) // Excluye eliminados
                       .ToListAsync();

            }
            public async Task<People> GetPeopleByIdAsync(int id)

            {

                return await _context.People

                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);

            }

            public async Task SoftDeletPeopletAsync(int id)

            {
                var people = await _context.People.FindAsync(id);
                if (people!= null)
                {
                    people.IsDeleted = true;
                    await _context.SaveChangesAsync();
                }
            }



        }

    }

        
    
}
