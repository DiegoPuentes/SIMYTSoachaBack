using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface ITrafficService
    {
        Task<IEnumerable<TrafficLicenses>> GetAllTrafficLicensesAsync();
        Task<TrafficLicenses> GetTrafficLicensesByIdAsync(int id);
        Task<TrafficLicenses> CreateTrafficLicensesAsync(string plate, int vstate, int tid,
            int vid, int pid, bool isdeleted);
        Task UpdateTrafficLicensesAsync(TrafficLicenses trafficLicenses);
        Task SoftDeleteTrafficLicensesAsync(int id);
    }
    public class TrafficService : ITrafficService
    {
        private readonly ITrafficRepository traffic;
        public TrafficService(ITrafficRepository trafficRepository)
        {
            traffic = trafficRepository;
        }

        public Task<TrafficLicenses> CreateTrafficLicensesAsync(string plate, int vstate, int tid, int vid, int pid, bool isdeleted)
        {
            return traffic.CreateTrafficLicensesAsync(plate, vstate, tid, vid, pid, isdeleted);
        }

        public Task<IEnumerable<TrafficLicenses>> GetAllTrafficLicensesAsync()
        {
            return traffic.GetAllTrafficLicensesAsync();
        }

        public Task<TrafficLicenses> GetTrafficLicensesByIdAsync(int id)
        {
            return traffic.GetTrafficLicensesByIdAsync(id);
        }

        public Task SoftDeleteTrafficLicensesAsync(int id)
        {
            return traffic.SoftDeleteTrafficLicensesAsync(id);
        }

        public Task UpdateTrafficLicensesAsync(TrafficLicenses trafficLicenses)
        {
            return traffic.UpdateTrafficLicensesAsync(trafficLicenses);
        }
    }
}
