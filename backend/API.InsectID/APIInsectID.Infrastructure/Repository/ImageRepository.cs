using APIInsectID.Application.Contracts;
using APIInsectID.Application.Models;
using APIInsectID.Domain.Entities;
using APIInsectID.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace APIInsectID.Infrastructure.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly PostgresDBContext _dbContext; // Asegúrate de tener un DbContext para interactuar con PostgreSQL

        public ImageRepository(PostgresDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultClasificationEntity> GuardarImagenBD(ImageModel request)
        {
            var arch = new GalleriesEntity()
            {
                Contain = request.Contain,
                Name = request.Name,
                Extension = request.Extension,
                dateCreate = DateTime.UtcNow.AddHours(-5),
                Category = "Imagen de usuario",
                isProcessed = false
            };

            _dbContext.Galleries.Add(arch);

            var resultado = await _dbContext.SaveChangesAsync();
            ResultClasificationEntity? resultadoConsulta = null;

            if (resultado > 0)
            {
                // Lanzar la tarea en segundo plano para procesar la imagen
              await  Task.Run(async () =>
                {
                    // Lógica de procesamiento de la imagen aquí
                    // Por ejemplo, ejecutar una consulta y esperar su resultado
                    resultadoConsulta = await RealizarConsultaAsync(arch.Id);

                    // Guardar los cambios en la base de datos
                    await _dbContext.SaveChangesAsync();

                });
                return resultadoConsulta;
            }

            throw new Exception("No se pudo guardar el archivo");
        }

        // Método de ejemplo para simular una consulta en segundo plano
        private async Task<ResultClasificationEntity> RealizarConsultaAsync(int id)
        {
            int intentosMaximos = 99999999; // Número máximo de intentos
            int intervaloEntreIntentosSegundos = 1; // Intervalo entre intentos en segundos

            for (int intento = 1; intento <= intentosMaximos; intento++)
            {
                var galeria = await _dbContext.Galleries
                    .Where(g => g.Id == id && g.isProcessed)
                    .FirstOrDefaultAsync();

                if (galeria != null)
                {
                    // Se encontró un resultado que cumple con la condición

                    // Realizar otro select para obtener la entidad completa
                    var entidadCompleta = await _dbContext.ResultClassification
                    .Include(r => r.GalleriesEntity) // Carga la propiedad de navegación GalleryEntity
                    .Where(r => r.GalleriesEntityId == id)
                    .FirstOrDefaultAsync();



                    return entidadCompleta;
                }

                // Esperar antes de realizar el próximo intento
                await Task.Delay(TimeSpan.FromSeconds(intervaloEntreIntentosSegundos));
            }

            // No se encontraron resultados después de varios intentos
            return null;
        }



    }
}
