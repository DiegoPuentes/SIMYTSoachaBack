using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IPeopleService
    {
        Task<IEnumerable<People>> GetAllPeoplesAsync();
        Task<People> GetPeopleByIdAsync(int id);
        Task CreatePeopleAsync(People people);
        Task UpdatePeopleAsync(People people);
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

        public async Task CreatePeopleAsync(People people)
        {
            await _peopleRepository.CreatePeopleAsync(people);
        }

        public async Task UpdatePeopleAsync(People people)
        {
            await _peopleRepository.UpdatePeopleAsync(people);
        }

        public async Task SoftDeletePeopleAsync(int id)
        {
            await _peopleRepository.SoftDeletePeopleAsync(id);
        }
    }
}
