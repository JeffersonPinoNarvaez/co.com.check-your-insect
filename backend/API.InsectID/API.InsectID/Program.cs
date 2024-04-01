using APIInsectID.Application.Contracts;
using APIInsectID.Infrastructure.Persistence;
using APIInsectID.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración del CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Add services to the container.

//Configuración del entorno
var environment = builder.Environment;
//Cargar configuraciones del archivo appsettings.json por defecto
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
//Cargar configuraciones de otros entornos en appsettings
builder.Configuration.AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

// Configuración del contexto de base de datos Oracle
builder.Services.AddDbContext<PostgresDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostGresDB"))
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region dependency injection
builder.Services.AddScoped<IImageRepository, ImageRepository>();
//builder.Services.AddHostedService<ImageProcessingService>();
#endregion dependency injection

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Agregar el middleware CORS antes de MapControllers()
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
