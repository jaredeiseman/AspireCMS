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
    [HttpGet("/api/page/{PageId}/content")]
    public class GetContentBlocks : Endpoint<GetContentBlocksRequest, ContentBlocksResponse>
    {
        private IContentBlockService _contentBlockService;

        public GetContentBlocks(IContentBlockService contentBlockService)
        {
            _contentBlockService = contentBlockService;
        }

        public override async Task HandleAsync(GetContentBlocksRequest request, CancellationToken ct)
        {
            List<ContentBlock> content = _contentBlockService.GetContentBlocks(request.PageId);

            if (content != null && content.Count > 0)
            {
                await SendAsync(new ContentBlocksResponse(content));
            }
            else
            {
                await SendNotFoundAsync();
            }
        }
    }
}
