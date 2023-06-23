using LabFashion.Database.Repositories.Interfaces;
using LabFashion.Database.Repositories;
using LabFashion.Services.Interfaces;
using LabFashion.Services;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using LabFashion.Database;
using LabFashion.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LabFashionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbLabFashion")));

builder.Services.AddAutoMapperConfiguration();

builder.Services.AddScoped<IUsuariosService, UsuariosService>();
builder.Services.AddScoped<IColecoesService, ColecoesService>();
builder.Services.AddScoped<IModelosService, ModelosService>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<IColecoesRepository, ColecoesRepository>();
builder.Services.AddScoped<IModelosRepository, ModelosRepository>();


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