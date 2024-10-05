using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IRequestService
    {
        Task<IEnumerable<Requests>> GetAllRequestsAsync();
        Task<Requests> GetRequestsByIdAsync(int id);
        Task<Requests> CreateRequestAsync(int pid, DateTime date, int officer, bool isde);
        Task UpdateRequestAsync(Requests requests);
        Task SoftDeleteRequestsByIdAsync(int id);
    }
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        public RequestService(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public Task<Requests> CreateRequestAsync(int pid, DateTime date, int officer, bool isde)
        {
            return _requestRepository.CreateRequestAsync(pid, date, officer, isde);
        }

        public Task<IEnumerable<Requests>> GetAllRequestsAsync()
        {
            return _requestRepository.GetAllRequestsAsync();
        }

        public Task<Requests> GetRequestsByIdAsync(int id)
        {
            return _requestRepository.GetRequestsByIdAsync(id);
        }

        public Task SoftDeleteRequestsByIdAsync(int id)
        {
            return _requestRepository.SoftDeleteRequestsByIdAsync(id);
        }

        public Task UpdateRequestAsync(Requests requests)
        {
            return _requestRepository.UpdateRequestAsync(requests);
        }
    }
}
