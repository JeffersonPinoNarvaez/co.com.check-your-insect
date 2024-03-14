using APIInsectID.Application.Models;
using APIInsectID.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIInsectID.Application.Contracts
{
    public interface IImageRepository
    {
        Task<ResultClasificationEntity> GuardarImagenBD(ImageModel request);
    }
}
