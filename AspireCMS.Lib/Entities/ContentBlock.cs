using AspireCMS.Enums;
using System.ComponentModel.DataAnnotations;

namespace AspireCMS.Entities
{
    public class ContentBlock
    {
        [Key]
        public Guid ContentBlockId { get; set; }

        public Guid PageId { get; set; }
        
        public Page Page { get; set; }
        
        public BlockType BlockType { get; set; }
        
        public string Content {  get; set; }
        
        public Guid? MediaId { get; set; }
        
        public Media? Media { get; set; }
        
        public int Position { get; set; }
    }
}