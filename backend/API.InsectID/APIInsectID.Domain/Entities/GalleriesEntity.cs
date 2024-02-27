

namespace APIInsectID.Domain.Entities
{
    public class GalleriesEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] Contain { get; set; }
        public string Category { get; set; }
        public bool isProcessed { get; set; }
        public DateTime dateCreate { get; set; }
    }
}
