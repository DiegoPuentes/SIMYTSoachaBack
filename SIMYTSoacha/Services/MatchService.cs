using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IMatchServices
    {
        Task<IEnumerable<Matches>> GetallMatchAsync();
        Task<Matches> GetMatchesByIdAsync(int id);
        Task CreateMatchesAsync(Matches match);
        Task UpdateMatchesAsync(Matches match);
        Task DeleteMatchesAsync(int id);
    }

    public class MatchService : IMatchServices
    {
        private readonly IMatchRepository _matchRepository;

        public MatchService(IMatchRepository match)
        {
            _matchRepository = match;

        }

        public Task CreateMatchesAsync(Matches match)
        {
          return _matchRepository.CreateMatchesAsync(match);

        }

        public Task DeleteMatchesAsync(int id)
        {
            return _matchRepository.DeleteMatchesAsync(id);

        }

        public Task<IEnumerable<Matches>> GetallMatchAsync()
        {
            return _matchRepository.GetallMatchAsync();

        }

        public Task<Matches> GetMatchesByIdAsync(int id)
        {
            return _matchRepository.GetMatchesByIdAsync(id);
        }

        public Task UpdateMatchesAsync(Matches match)
        {
            return _matchRepository.UpdateMatchesAsync(match);
        }
    }
}
