using SIMYTSoacha.Context;
using SIMYTSoacha.Model;
using SIMYTSoacha.Repository;

namespace SIMYTSoacha.Services
{
    public interface IPeopleService
    {
        Task<IEnumerable<People>> GetAllPeopleAsync();

        Task<People> GetPeopleByIdAsync(int id);

        Task CreatePeopleAsync(People subject);

        Task UpdatePeopleAsync(People subject);

        Task SoftDeletePeopleAsync(int id);
    }
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _PeopleRepository;
        public PeopleService(IPeopleRepository peopleRepository)
        {
            _PeopleRepository = peopleRepository;
        }
        public async Task<IEnumerable<People>> GetAllPeopleAsync()
        {

            return await _PeopleRepository.GetAllPeopleAsync();

        }
        public async Task<People> GetPeopleByIdAsync(int id)

        {

            return await _PeopleRepository.GetPeopleByIdAsync(id);

            .FirstOrDefaultAsync(s => s.Id id && !s.IsDeleted);

        }

    }
}
