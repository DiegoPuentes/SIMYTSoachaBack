using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface ILineService
    {
        Task<IEnumerable<Lines>> GetAllLinesAsync();
        Task<Lines> GetLinesByIdAsync(int id);
        Task<bool> CreateLinesAsync(Lines lines);
        Task UpdateLinesAsync(Lines lines);
        Task SoftDeleteLinesAsync(int id);
    }
    public class LineService : ILineService
    {
        private readonly ILineRepository _lineRepository;
        private readonly IPeopleService _peopleService;
        private readonly IHttpContextAccessor _contextAccessor;
        public LineService(ILineRepository lineRepository, IPeopleService peopleService,
            IHttpContextAccessor httpContextAccessor) 
        {
            _lineRepository = lineRepository;
            _peopleService = peopleService;
            _contextAccessor = httpContextAccessor;
        }

        public async Task<bool> CreateLinesAsync(Lines lines)
        {
            int? userType = _contextAccessor.HttpContext.Session.GetInt32("UserTypeId");
            if (userType != null)
            {
                if (await _peopleService.PermissionAsync(userType.Value, 1))
                {
                    await _lineRepository.CreateLinesAsync(lines); ;
                    return true;
                }
                return false;
            }
            return false;
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
