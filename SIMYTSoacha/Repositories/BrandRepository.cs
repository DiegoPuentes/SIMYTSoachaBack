using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Model;

namespace SIMYTSoacha.Repositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brands>> GetAllBrandsAsync();
        Task<Brands> GetBrandsByIdAsync(int id);
        Task CreateBrandsAsync(Brands brand);
        Task UpdateBrandsAsync(Brands brand);
        Task SoftDeleteBrandsAsync(int id);
    }
    public class BrandRepository : IBrandRepository
    {
        public readonly SimytDbContext context;
        public BrandRepository(SimytDbContext simytDbContext)
        {
            context = simytDbContext;
        }
        public async Task CreateBrandsAsync(Brands brand)
        {
            context.Brands.Add(brand);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Brands>> GetAllBrandsAsync()
        {
            return await context.Brands
                .Where(s => !s.IsDeleted)
                .ToListAsync();
        }

        public async Task<Brands> GetBrandsByIdAsync(int id)
        {
            return await context.Brands.
                FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted);
        }

        public async Task SoftDeleteBrandsAsync(int id)
        {
            var subject = await context.Brands.FindAsync(id);
            if (subject != null)
            {
                subject.IsDeleted = true;
                await context.SaveChangesAsync();
            }

        }

        public async Task UpdateBrandsAsync(Brands brand)
        {
            context.Brands.Update(brand);
            await context.SaveChangesAsync();
        }
    }
}
