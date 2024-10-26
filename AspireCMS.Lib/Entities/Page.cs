using System.ComponentModel.DataAnnotations;

namespace AspireCMS.Entities
{
    public class Page
    {
        [Key]
        public Guid PageId { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Slug { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        public DateTime? UpdatedDate { get; set; } = null;
        
        public bool IsPublished { get; set; } = false;
    }
}