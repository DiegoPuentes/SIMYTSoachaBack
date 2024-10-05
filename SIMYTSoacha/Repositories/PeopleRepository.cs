using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SIMYTSoacha.Repositories
{
    public interface IPeopleRepository
    {
        Task<IEnumerable<People>> GetAllPeopleAsync();
        Task<People> GetSubjectByIdAsync(int id);
        Task<People> CreatePeopleAsync(string name, string lnames, int dtypeid, string ndocument,
            int sex, DateTime date, int utypeid, string user, string password, bool isdeleted);
        Task UpdatePeopleAsync(string name, string lnames, int dtypeid, string ndocument,
            int sex, DateTime date, int utypeid, string user, string password, bool isdeleted);
        Task SoftDeletePeopleAsync(int id);
    }
    public class PeopleRepository : IPeopleRepository
    {
        private readonly SimytDbContext _context;
        public PeopleRepository(SimytDbContext context)
        {
            _context = context;
        }
        public async Task<People> CreatePeopleAsync(string name, string lnames, int dtypeid, string ndocument, 
            int sex, DateTime date, int utypeid, string user, string password, bool isdeleted)
        {
            People people = new People
            {
                Names = name,
                Lnames = lnames,
                DtypeId = dtypeid,
                DocumentType = null,
                Ndocument = ndocument,
                SexId = sex,
                Sex = null,
                DateBirth = date,
                UserTypeId = utypeid,
                UserType = null,
                UserName = user,
                Password = password,
                Isdeleted = isdeleted
            };
            _context.People.Add(people);
            await _context.SaveChangesAsync();
            return people;
        }

        public async Task<IEnumerable<People>> GetAllPeopleAsync()
        {
            return await _context.People
                .Where(s => !s.Isdeleted)
                .ToListAsync();
        }

        public async Task<People> GetSubjectByIdAsync(int id)
        {
            return await _context.People
                .FirstOrDefaultAsync(s => s.PeopleId == id && !s.Isdeleted);
        }

        public async Task SoftDeletePeopleAsync(int id)
        {
            var subject = await _context.People.FindAsync(id);
            if (subject != null)
            {
                subject.Isdeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdatePeopleAsync(string name, string lnames, int dtypeid, string ndocument, 
            int sex, DateTime date, int utypeid, string user, string password, bool isdeleted)
        {
            People updatePeople = new People
            {
                Names = name,
                Lnames = lnames,
                DtypeId = dtypeid,
                DocumentType = null,
                Ndocument = ndocument,
                SexId = sex,
                Sex = null,
                DateBirth = date,
                UserTypeId = utypeid,
                UserType = null,
                UserName = user,
                Password = password,
                Isdeleted = isdeleted
            };
            _context.People.Update(updatePeople);
            await _context.SaveChangesAsync();
        }
    }
}
