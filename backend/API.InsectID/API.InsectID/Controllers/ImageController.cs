using APIInsectID.Application.Contracts;
using APIInsectID.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Threading;

namespace API.InsectID.Controllers
{
    [ApiController]
    [Route("api/images")]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpPost("PostImage")]
        public async Task<IActionResult> PostImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Archivo no válido");
            }

            try
            {
                // Leer los bytes del archivo
                byte[] fileBytes;
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }

                // Crear el objeto ImageModel
                var imageModel = new ImageModel
                {
                    Contain = fileBytes,
                    Name = Path.GetFileNameWithoutExtension(file.FileName),
                    Extension = file.ContentType,
                };

                // Llamar al método para guardar la imagen en la base de datos
                var result = await _imageRepository.GuardarImagenBD(imageModel);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }



    }
}
