using AspireCMS.ApiService.Contexts;
using AspireCMS.ApiService.DTOs.ContentBlocks.Requests;
using AspireCMS.ApiService.DTOs.ContentBlocks.Responses;
using AspireCMS.Entities;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace AspireCMS.ApiService.Endpoints.ContentBlocks
{
    [AllowAnonymous]
    [HttpPost("/api/contentblock")]
    public class CreateContentBlock : Endpoint<CreateContentBlockRequest, ContentBlockResponse>
    {
        public CMSContext Context { get; set; }

        public override async Task HandleAsync(CreateContentBlockRequest req, CancellationToken ct)
        {
            ContentBlock newBlock = new ContentBlock()
            {
                BlockType = req.BlockType,
                Content = req.Content,
                PageId = req.PageId,
                Position = req.Position
            };

            var blocksToShift = Context.ContentBlocks.Where(cb => cb.Position >= newBlock.Position);

            if (blocksToShift.Any())
            {
                foreach (var block in blocksToShift)
                {
                    block.Position++;
                }
            }

            Context.ContentBlocks.Add(newBlock);

            await Context.SaveChangesAsync();

            await SendAsync(new ContentBlockResponse(newBlock));
        }
    }
}
