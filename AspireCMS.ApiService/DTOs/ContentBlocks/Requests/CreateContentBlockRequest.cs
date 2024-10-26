using AspireCMS.Enums;

namespace AspireCMS.ApiService.DTOs.ContentBlocks.Requests
{
    public class CreateContentBlockRequest
    {
        public BlockType BlockType { get; set; }
        public string Content { get; set; }
        public Guid PageId { get; set; }
        public int Position { get; set; }
    }
}