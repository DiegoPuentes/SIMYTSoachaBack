using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IColorService
    {
        Task<IEnumerable<Colors>> GetAllColorAsync();
        Task<Colors> GetColorByIdAsync(int id);
        Task CreateColorAsync(Colors colors);
        Task UpdateColorAsync(Colors colors);
        Task SoftDeleteColorAsync(int id);
    }

    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;
        public ColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public Task CreateColorAsync(Colors colors)
        {
            return _colorRepository.CreateColorAsync(colors);
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
