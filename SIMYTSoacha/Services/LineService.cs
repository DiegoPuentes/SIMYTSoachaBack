using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface ILineService
    {
        Task<IEnumerable<Lines>> GetAllLinesAsync();
        Task<Lines> GetLinesByIdAsync(int id);
        Task CreateLinesAsync(Lines lines);
        Task UpdateLinesAsync(Lines lines);
        Task SoftDeleteLinesAsync(int id);
    }
    public class LineService : ILineService
    {
        private readonly ILineRepository _lineRepository;
        public LineService(ILineRepository lineRepository) 
        {
            _lineRepository = lineRepository;
        }

        public Task CreateLinesAsync(Lines lines)
        {
            return _lineRepository.CreateLinesAsync(lines);
        }

        public Task SoftDeleteLinesAsync(int id)
        {
            return _lineRepository.SoftDeleteLinesAsync(id);
        }

        public Task<IEnumerable<Lines>> GetAllLinesAsync()
        {
            return _lineRepository.GetAllLinesAsync();
        }

        public Task<Lines> GetLinesByIdAsync(int id)
        {
            return _lineRepository.GetLinesByIdAsync(id);
        }

        public Task UpdateLinesAsync(Lines lines)
        {
            return _lineRepository.UpdateLinesAsync(lines);
        }
    }
}
