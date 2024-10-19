using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IDriverService
    {
        Task<IEnumerable<DriverLicenses>> GetAllDriverAsync();
        Task<DriverLicenses> GetDriverByIdAsync(int id);
        Task<DriverLicenses> CreateDriverAsync(int nlicense, int Eid, DateTime date,
            int Sid, int Rid, int Pid, bool isdeleted);
        Task UpdateDriverAsync(DriverLicenses driverLicenses);
        Task SoftDeleteDriverAsync(int id);
    }

    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IPeopleRepository _peopleRepository;

        public DriverService(IDriverRepository driverRepository, IPeopleRepository peopleRepository)
        {
            _driverRepository = driverRepository;
            _peopleRepository = peopleRepository;
        }

        public Task<DriverLicenses> CreateDriverAsync(int nlicense, int Eid, DateTime date,
            int Sid, int Rid, int Pid, bool isdeleted)
        {
            return _driverRepository.CreateDriverAsync(nlicense, Eid, date, Sid, Rid, Pid, isdeleted);
        }

        public Task<IEnumerable<DriverLicenses>> GetAllDriverAsync()
        {
            return _driverRepository.GetAllDriverAsync();
        }

        public Task<DriverLicenses> GetDriverByIdAsync(int id)
        {
            return _driverRepository.GetDriverByIdAsync(id);
        }

        public Task SoftDeleteDriverAsync(int id)
        {
            return _driverRepository.SoftDeleteDriverAsync(id);
        }

        public Task UpdateDriverAsync(DriverLicenses driverLicenses)
        {
            return _driverRepository.UpdateDriverAsync(driverLicenses);
        }
    }
}
