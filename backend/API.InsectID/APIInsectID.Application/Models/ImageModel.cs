using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInsectID.Application.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public byte[] Bytes { get; set; }

        // Otras propiedades relevantes de la metadata de la imagen

        // Asegúrate de tener relaciones con otras entidades si es necesario    
    }
}
