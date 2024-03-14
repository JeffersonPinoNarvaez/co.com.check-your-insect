
using System.ComponentModel.DataAnnotations.Schema;

namespace APIInsectID.Domain.Entities
{
    public class ResultClasificationEntity
    {
        public int Id { get; set; }
        public int GalleriesEntityId { get; set; }

        [Column(TypeName = "TEXT")]
        public string ResultsClassified { get; set; }

        public GalleriesEntity GalleriesEntity { get; set; }
    }
}
