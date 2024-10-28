using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IColorService
    {
        Task<IEnumerable<Colors>> GetAllColorAsync();
        Task<Colors> GetColorByIdAsync(int id);
        Task<bool> CreateColorAsync(Colors colors);
        Task UpdateColorAsync(Colors colors);
        Task SoftDeleteColorAsync(int id);
    }

    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;
        private readonly IPeopleService _peopleService;
        private readonly IHttpContextAccessor _contextAccessor;
        public ColorService(IColorRepository colorRepository, IPeopleService peopleService
            , IHttpContextAccessor httpContextAccessor)
        {
            _colorRepository = colorRepository;
            _peopleService = peopleService;
            _contextAccessor = httpContextAccessor;
        }

        public async Task<bool> CreateColorAsync(Colors colors)
        {
            int? userType = _contextAccessor.HttpContext.Session.GetInt32("UserTypeId");
            if (userType != null)
            {
                if (await _peopleService.PermissionAsync(userType.Value, 1))
                {
                    await _colorRepository.CreateColorAsync(colors);
                    return true;
                }
                return false;
            }
            return false;
        }

        public Task<IEnumerable<Colors>> GetAllColorAsync()
        {
            return _colorRepository.GetAllColorAsync();
        }

        public Task<Colors> GetColorByIdAsync(int id)
        {
            return _colorRepository.GetColorByIdAsync(id);
        }

        public Task SoftDeleteColorAsync(int id)
        {
            return _colorRepository.SoftDeleteColorAsync(id);
        }

        public Task UpdateColorAsync(Colors colors)
        {
            return _colorRepository.UpdateColorAsync(colors);
        }
    }
}
