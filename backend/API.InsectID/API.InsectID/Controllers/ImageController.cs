using APIInsectID.Application.Contracts;
using APIInsectID.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

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


        [HttpPost("ObtenerMetadata")]
        public ActionResult<string> ObtenerMetadata()
        {
            try
            {
                var archivo = Request.Form.Files["archivo"];

                // Verificar que se haya enviado un archivo
                if (archivo != null && archivo.Length > 0)
                {
                    // Verificar que el archivo sea una imagen
                    if (archivo.ContentType.StartsWith("image/"))
                    {
                        // Obtener la metadata de la imagen
                        var metadata = ObtenerMetadataImagen(archivo);

                        // Puedes retornar la metadata en el formato que desees
                        return Ok(new { StatusCode = 200, Response = $"{metadata}" });
                    }
                    else
                    {
                        return BadRequest(new { StatusCode = 400, Response = "El archivo no es una imagen válida." });
                    }
                }
                else
                {
                    return BadRequest(new { StatusCode = 400, Response = "No se ha enviado ningún archivo." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, Response = $"Error interno del servidor: {ex.Message}" });
            }
        }

        [HttpPost("GuardarImagen")]
        public ActionResult<string> GuardarImagen()
        {
            try
            {
                var archivo = Request.Form.Files["archivo"];

                if (archivo != null && archivo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        archivo.CopyTo(memoryStream);
                        var bytes = memoryStream.ToArray();

                        // Guardar en la base de datos
                        var imagenModel = new ImageModel { Bytes = bytes };
                        // Aquí deberías usar tu contexto de base de datos para agregar y guardar el modelo
                        // dbContext.Imagenes.Add(imagenModel);
                        // dbContext.SaveChanges();
                        return Ok(new { StatusCode = 200, Response = $"Imagen guardada exitosamente en la base de datos. {archivo.FileName}, {archivo.Headers}, {archivo.ContentType}" });
                    }
                }
                else
                {
                    return BadRequest(new { StatusCode = 400, Response = "El archivo no es una imagen válida." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { StatusCode = 500, Response = $"Error interno del servidor: {ex.Message}" });
            }
        }

        #region private methods
        private string ObtenerMetadataImagen(IFormFile archivo)
        {
            // Convertir el archivo a un objeto Image
            using (var imagen = Image.FromStream(archivo.OpenReadStream()))
            {
                // Obtener la metadata de la imagen
                var metadata = $"Ancho: {imagen.Width}, Alto: {imagen.Height}, Formato: {imagen.RawFormat}, Nombre:{archivo.FileName}";

                // Puedes agregar más información de la metadata según tus necesidades

                return metadata;
            }
        }
        #endregion private methods

    }
}
