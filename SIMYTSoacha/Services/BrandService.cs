using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IBrandService
    {
        Task<IEnumerable<Brands>> GetAllBrandsAsync();
        Task<Brands> GetBrandsByIdAsync(int id);
        Task CreateBrandsAsync(Brands brand);
        Task UpdateBrandsAsync(Brands brand);
        Task SoftDeleteBrandsAsync(int id); 
    }

    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public Task CreateBrandsAsync(Brands brand)
        {
            return _brandRepository.CreateBrandsAsync(brand);
        }

        public Task<IEnumerable<Brands>> GetAllBrandsAsync()
        {
            return _brandRepository.GetAllBrandsAsync();
        }

        public Task<Brands> GetBrandsByIdAsync(int id)
        {
            return _brandRepository.GetBrandsByIdAsync(id);
        }

        public Task SoftDeleteBrandsAsync(int id)
        {
            return _brandRepository.SoftDeleteBrandsAsync(id);
        }

        public Task UpdateBrandsAsync(Brands brand)
        {
            return _brandRepository.UpdateBrandsAsync(brand);
        }
    } 
}
