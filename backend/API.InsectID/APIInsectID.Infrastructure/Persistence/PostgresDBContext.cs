using APIInsectID.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        public virtual DbSet<GalleriesEntity> Galleries { get; set; }
        public virtual DbSet<ResultClasificationEntity> ResultClassification { get; set; }

    }
}
