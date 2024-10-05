using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IProcedureService
    {
        Task<IEnumerable<Procedures>> GetAllProceduresAsync();
        Task<Procedures> GetProceduresByIdAsync(int id);
        Task<Procedures> CreateProceduresAsync(int p, int sid, int rid, bool isde);
        Task UpdateProceduresAsync(Procedures procedures);
        Task SoftDeleteProceduresAsync(int id);
    }
    public class ProcedureService : IProcedureService
    {
        private readonly IProcedureRepository repository;
        public ProcedureService(IProcedureRepository repositoryProce)
        {
            repository = repositoryProce;
        }

        public Task<Procedures> CreateProceduresAsync(int p, int sid, int rid, bool isde)
        {
            return repository.CreateProceduresAsync(p, sid, rid, isde);
        }

        public Task<IEnumerable<Procedures>> GetAllProceduresAsync()
        {
            return repository.GetAllProceduresAsync();
        }

        public Task<Procedures> GetProceduresByIdAsync(int id)
        {
            return repository.GetProceduresByIdAsync(id);
        }

        public Task SoftDeleteProceduresAsync(int id)
        {
            return repository.SoftDeleteProceduresAsync(id);
        }

        public Task UpdateProceduresAsync(Procedures procedures)
        {
            return repository.UpdateProceduresAsync(procedures);
        }
    }
}
