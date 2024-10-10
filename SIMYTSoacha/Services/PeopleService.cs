using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IPeopleService
    {
        Task<IEnumerable<People>> GetAllPeoplesAsync();
        Task<People> GetPeopleByIdAsync(int id);
        Task<People> CreatePeopleAsync(string name, string lnames, int dtypeid, string ndocument,
            int sex, DateTime date, int utypeid, string user, string password, bool isdeleted);
        Task UpdatePeopleAsync(People people);
        Task SoftDeletePeopleAsync(int id);
        Task<People> LoginAsync(string user, string pass);
        Task<bool> PermissionAsync(int id);
    }

    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleService(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        public async Task<IEnumerable<People>> GetAllPeoplesAsync()
        {
            return await _peopleRepository.GetAllPeopleAsync();
        }

        public async Task<People> GetPeopleByIdAsync(int id)
        {
            return await _peopleRepository.GetSubjectByIdAsync(id);
        }

        public async Task<People> CreatePeopleAsync(string name, string lnames, int dtypeid, 
            string ndocument, int sex, DateTime date, int utypeid, string user, string password, 
            bool isdeleted)
        {
            return await _peopleRepository.CreatePeopleAsync(name, lnames, dtypeid, ndocument, 
                sex, date, utypeid, user, password, isdeleted);
        }

        public async Task UpdatePeopleAsync(People people)
        {
            await _peopleRepository.UpdatePeopleAsync(people);
        }

        public async Task SoftDeletePeopleAsync(int id)
        {
            await _peopleRepository.SoftDeletePeopleAsync(id);
        }

        public async Task<People> LoginAsync(string user, string pass)
        {
            return await _peopleRepository.LoginAsync(user, pass); 
        }

        public async Task<bool> PermissionAsync(int id)
        {
            return await _peopleRepository.PermissionAsync(id);
        }
    }
}
