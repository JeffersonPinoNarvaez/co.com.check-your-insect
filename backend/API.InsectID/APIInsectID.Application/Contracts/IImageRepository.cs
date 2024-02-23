using APIInsectID.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInsectID.Application.Contracts
{
    public interface IImageRepository
    {
        ImageModel GetImageMetadata(byte[] imageData);
        //void SaveImageMetadata(ImageMetaData imageMetadata);
    }
}
