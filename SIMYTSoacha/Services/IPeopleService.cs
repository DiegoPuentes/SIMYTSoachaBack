using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IPeopleService
    {
        Task<IEnumerable<People>> GetAllPeoplesAsync();
        Task<People> GetPeopleByIdAsync(int id);
        Task<People> CreatePeopleAsync(string name, string lnames, int dtypeid, string ndocument, string sex, DateTime date, int utypeid, bool isdeleted);
        Task UpdatePeopleAsync(string name, string lnames, int dtypeid, string ndocument, string sex, DateTime date, int utypeid, bool isdeleted);
        Task SoftDeletePeopleAsync(int id);
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

        public async Task<People> CreatePeopleAsync(string name, string lnames, int dtypeid, string ndocument, string sex, DateTime date, int utypeid, bool isdeleted)
        {
            return await _peopleRepository.CreatePeopleAsync(name, lnames, dtypeid, ndocument, sex, date, utypeid, isdeleted);
        }

        public async Task UpdatePeopleAsync(string name, string lnames, int dtypeid, string ndocument, string sex, DateTime date, int utypeid, bool isdeleted)
        {
            await _peopleRepository.UpdatePeopleAsync(name, lnames, dtypeid, ndocument, sex, date, utypeid, isdeleted);
        }

        public async Task SoftDeletePeopleAsync(int id)
        {
            await _peopleRepository.SoftDeletePeopleAsync(id);
        }
    }
}
