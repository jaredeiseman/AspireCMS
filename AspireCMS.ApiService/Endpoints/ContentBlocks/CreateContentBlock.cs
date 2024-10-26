using AspireCMS.ApiService.Contexts;
using AspireCMS.ApiService.DTOs.ContentBlocks.Requests;
using AspireCMS.ApiService.DTOs.ContentBlocks.Responses;
using AspireCMS.Entities;
using AspireCMS.Interfaces;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace AspireCMS.ApiService.Endpoints.ContentBlocks
{
    [AllowAnonymous]
    [HttpPost("/api/contentblock")]
    public class CreateContentBlock : Endpoint<CreateContentBlockRequest, ContentBlockResponse>
    {
        private IContentBlockService _contentBlockService;

        public CreateContentBlock(IContentBlockService contentBlockService)
        {
            _contentBlockService = contentBlockService;
        }

        public override async Task HandleAsync(CreateContentBlockRequest req, CancellationToken ct)
        {
            ContentBlock newBlock = await _contentBlockService.CreateContentBlock(req.BlockType, req.Content, req.PageId, req.Position);

            await SendAsync(new ContentBlockResponse(newBlock));
        }
    }
}
