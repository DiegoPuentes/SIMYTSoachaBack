using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface ILxMService
    {
        Task<IEnumerable<LevelsxMatches>> GetAllLxMAsync();
        Task<LevelsxMatches> CreateLxMAsync(int id, int iid, bool isdeleted);
    }
    public class LxMService : ILxMService
    {
        private readonly ILxMRepository lxmRepository;
        public LxMService(ILxMRepository lxM)
        {
            lxmRepository = lxM;
        }

        public Task<LevelsxMatches> CreateLxMAsync(int id, int iid, bool isdeleted)
        {
            return lxmRepository.CreateLxMAsync(id, iid, isdeleted);
        }

        public Task<IEnumerable<LevelsxMatches>> GetAllLxMAsync()
        {
            return lxmRepository.GetAllLxMAsync();
        }
    }
}
