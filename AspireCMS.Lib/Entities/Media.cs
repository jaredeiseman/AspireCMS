using System.ComponentModel.DataAnnotations;

namespace AspireCMS.Entities
{
    public class Media
    {
        [Key]
        public Guid MediaId { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FilePath { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}