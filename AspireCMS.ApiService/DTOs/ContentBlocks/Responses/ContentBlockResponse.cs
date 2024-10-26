using AspireCMS.Entities;
using AspireCMS.Enums;

namespace AspireCMS.ApiService.DTOs.ContentBlocks.Responses
{
    public class ContentBlockResponse
    {
        public Guid ContentBlockId { get; set; }
        public Guid PageId { get; set; }
        public BlockType BlockType { get; set; }
        public string Content { get; set; }
        public Guid? MediaId { get; set; }
        public int Position { get; set; }

        public ContentBlockResponse(ContentBlock block)
        {
            ContentBlockId = block.ContentBlockId;
            PageId = block.PageId;
            BlockType = block.BlockType;
            Content = block.Content;
            MediaId = block.MediaId;
            Position = block.Position;
        }
    }
}
