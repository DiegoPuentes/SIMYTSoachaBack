using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IBrandService
    {
        Task<IEnumerable<Brands>> GetAllBrandsAsync();
        Task<Brands> GetBrandsByIdAsync(int id);
        Task<bool> CreateBrandsAsync(Brands brand);
        Task UpdateBrandsAsync(Brands brand);
        Task SoftDeleteBrandsAsync(int id); 
    }

    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IPeopleService _peopleService;
        private readonly IHttpContextAccessor _contextAccessor;
        public BrandService(IBrandRepository brandRepository, IPeopleService peopleService,
            IHttpContextAccessor contextAccessor)
        {
            _brandRepository = brandRepository;
            _peopleService = peopleService;
            _contextAccessor = contextAccessor;
        }

        public async Task<bool> CreateBrandsAsync(Brands brand)
        {
            int? userType = _contextAccessor.HttpContext.Session.GetInt32("UserTypeId");
            if (userType!=null)
            {
                if (await _peopleService.PermissionAsync(userType.Value, 1))
                {
                    await _brandRepository.CreateBrandsAsync(brand);
                    return true;
                }
                return false;
            }
            return false;
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
