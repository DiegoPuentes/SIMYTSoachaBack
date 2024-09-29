using Microsoft.EntityFrameworkCore;
using SIMYTSoacha.Context;
using SIMYTSoacha.Repositories;
using SIMYTSoacha.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<SimytDbContext>(options => options.UseSqlServer(conString));

builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();
builder.Services.AddScoped<IDocRepository, DocTypeRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

builder.Services.AddScoped<IPeopleService, PeopleService>();
builder.Services.AddScoped<IDocService, DocService>();
builder.Services.AddScoped<IContactService, ContactService>();

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
