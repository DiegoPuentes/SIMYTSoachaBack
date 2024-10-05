using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IModelService
    {
        Task<IEnumerable<Models>> GetAllModelsAsync();
        Task<Models> GetModelsByIdAsync(int id);
        Task UpdateModelAsync(Models model);
        Task CreatModelAsync(Models model);
        Task SoftDeleteModelAsync(int id);
    }
    public class ModelService : IModelService
    {
        private readonly IModelRepository _model;
        public ModelService(IModelRepository modelRepository)
        {
            _model = modelRepository;
        }

        public Task CreatModelAsync(Models model)
        {
            return _model.CreateModelAsync(model);
        }

        public Task SoftDeleteModelAsync(int id)
        {
            return _model.SoftDeleteModelAsync(id);
        }

        public Task<IEnumerable<Models>> GetAllModelsAsync()
        {
            return _model.GetAllModelAsync();
        }

        public Task<Models> GetModelsByIdAsync(int id)
        {
            return _model.GetModelByIdAsync(id);
        }

        public Task UpdateModelAsync(Models model)
        {
            return _model.UpdateModelAsync(model);
        }
    }
}
