using SIMYTSoacha.Model;
using SIMYTSoacha.Repositories;

namespace SIMYTSoacha.Services
{
    public interface IModelService
    {
        Task<IEnumerable<Models>> GetAllModelsAsync();
        Task<Models> GetModelsByIdAsync(int id);
        Task UpdateModelAsync(Models model);
        Task<bool> CreatModelAsync(Models model);
        Task SoftDeleteModelAsync(int id);
    }
    public class ModelService : IModelService
    {
        private readonly IModelRepository _model;
        private readonly IPeopleService _peopleService;
        private readonly IHttpContextAccessor _contextAccessor;
        public ModelService(IModelRepository modelRepository, IPeopleService peopleService
            , IHttpContextAccessor contextAccessor)
        {
            _model = modelRepository;
            _peopleService = peopleService;
            _contextAccessor = contextAccessor;
        }

        public async Task<bool> CreatModelAsync(Models model)
        {
            int? userType = _contextAccessor.HttpContext.Session.GetInt32("UserTypeId");
            if (userType != null)
            {
                if (await _peopleService.PermissionAsync(userType.Value, 1))
                {
                    await _model.CreateModelAsync(model);
                    return true;
                }
                return false;
            }
            return false;
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
