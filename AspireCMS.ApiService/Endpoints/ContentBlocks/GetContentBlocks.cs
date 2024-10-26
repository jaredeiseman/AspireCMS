using AspireCMS.ApiService.Contexts;
using AspireCMS.ApiService.DTOs.ContentBlocks.Requests;
using AspireCMS.ApiService.DTOs.ContentBlocks.Responses;
using AspireCMS.Entities;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace AspireCMS.ApiService.Endpoints.ContentBlocks
{
    [AllowAnonymous]
    [HttpGet("/api/page/{PageId}/content")]
    public class GetContentBlocks : Endpoint<GetContentBlocksRequest, ContentBlocksResponse>
    {
        public CMSContext Context { get; set; }

        public override async Task HandleAsync(GetContentBlocksRequest request, CancellationToken ct)
        {
            List<ContentBlock> content = Context.ContentBlocks.Where(cb => cb.PageId == request.PageId).OrderBy(cbs => cbs.Position).ToList();

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
