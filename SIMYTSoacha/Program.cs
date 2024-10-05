using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Repositories;
using SIMYTSoacha.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<SimytDbContext>(options => options.UseSqlServer(conString));

builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<ICenterRepository, CenterRepository>();
builder.Services.AddScoped<IFinesRepository, FinesRepository>();
builder.Services.AddScoped<IInfractionRepository, InfractionRepository>();
builder.Services.AddScoped<IRestrictionRepository, RestrictionRepository>();
builder.Services.AddScoped<ILineRepository, LineRepository>();
builder.Services.AddScoped<IImpositionRepository, ImpositionRepository>();
builder.Services.AddScoped<IModelRepository, ModelRepository>();
builder.Services.AddScoped<IMxLRepository, MxLRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IProcedureRepository, ProcedureRepository>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<ISexRepository, SexRepository>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<ITcontactRepository, TcontactRepository>();
builder.Services.AddScoped<ITserviceRepository, TserviceRepository>();
builder.Services.AddScoped<ITvehicleRepository, TvehicleRepository>();
builder.Services.AddScoped<IUsertRepository, UsertRepository>();
builder.Services.AddScoped<IUxPRepository, UxPRepository>();
builder.Services.AddScoped<ITrafficRepository, TrafficRepository>();
builder.Services.AddScoped<IHistoriesRepository, HistoriesRepository>();
builder.Services.AddScoped<ILevelsRepository, LevelsRepository>();
builder.Services.AddScoped<ILxMRepository, LxMRepository>();
//builder.Services.AddScoped<IContactRepository, ContactRepository>();

builder.Services.AddScoped<IPeopleService, PeopleService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<ICenterService, CenterService>();
builder.Services.AddScoped<IFinesService, FinesService>();
builder.Services.AddScoped<IInfractionService, InfractionService>();
builder.Services.AddScoped<IRestriService, RestriService>();
builder.Services.AddScoped<ILineService, LineService>();
builder.Services.AddScoped<IImpositionService, ImpositionService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IMxLService, MxLService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IProcedureService, ProcedureService>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<ISexService, SexService>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<ITcontactService, TcontactService>();
builder.Services.AddScoped<ITserviceService, TserviceService>();
builder.Services.AddScoped<ITvehicleService, TVehicleService>();
builder.Services.AddScoped<IUsertService, UsertService>();
builder.Services.AddScoped<IUxPService, UxPService>();
builder.Services.AddScoped<ITrafficService, TrafficService>();
builder.Services.AddScoped<IHistoriesService, HistoriesService>();
builder.Services.AddScoped<ILevelsService, LevelService>();
builder.Services.AddScoped<ILxMService, LxMService>();
//builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
