using AspireCMS.ApiService.Contexts;
using AspireCMS.ApiService.DTOs.Page.Responses;
using AspireCMS.Entities;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace AspireCMS.ApiService.Endpoints.Pages
{
    [AllowAnonymous]
    [HttpGet("/api/pages")]
    public class GetPages : EndpointWithoutRequest<PagesResponse>
    {
        public CMSContext Context { get; set; }

        public override async Task HandleAsync(CancellationToken ct)
        {
            List<Page> pages = Context.Pages.ToList();

            if (pages == null || pages.Count == 0)
                await SendNotFoundAsync();
            else
                await SendAsync(new PagesResponse(pages));
        }
    }
}
