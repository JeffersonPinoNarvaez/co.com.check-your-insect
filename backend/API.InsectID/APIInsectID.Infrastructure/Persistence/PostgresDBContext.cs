using APIInsectID.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace APIInsectID.Infrastructure.Persistence
{
    public class PostgresDBContext : DbContext
    {
        public PostgresDBContext()
        {
            // Constructor sin parámetros
        }

        public PostgresDBContext(DbContextOptions<PostgresDBContext> options) : base(options)
        {
        }

        public virtual DbSet<ImageEntity> Image { get; set; }

    }
}
