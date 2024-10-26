using AspireCMS.ApiService.Endpoints.ContentBlocks;
using AspireCMS.Entities;

namespace AspireCMS.ApiService.DTOs.ContentBlocks.Responses
{
    public class ContentBlocksResponse
    {
        public List<ContentBlockResponse> Content { get; set; }

        public ContentBlocksResponse(List<ContentBlock> blocks)
        {
            Content = new List<ContentBlockResponse>();

            foreach (var block in blocks)
            {
                Content.Add(new ContentBlockResponse(block));
            }

            if (Content.Count == 0)
            {
                Content = null;
            }
        }
    }
}
