using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInsectID.Application.Models
{
    public class ImageModel
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] Contain { get; set; }
        public string? Category { get; set; }
        public bool isProcessed { get; set; }
        public DateTime dateCreate { get; set; }
    }
}
