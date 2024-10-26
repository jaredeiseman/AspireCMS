using AspireCMS.ApiService.Contexts;
using AspireCMS.ApiService.DTOs.Page.Requests;
using AspireCMS.ApiService.DTOs.Page.Responses;
using AspireCMS.Entities;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace AspireCMS.ApiService.Endpoints.Pages
{
    [AllowAnonymous]
    [HttpGet("/api/page")]
    public class GetPage : Endpoint<PageRequest, PageResponse>
    {
        public CMSContext Context { get; set; }

        public override async Task HandleAsync(PageRequest req, CancellationToken ct)
        {
            Page page = Context.Pages.Where(p => p.Slug.Equals(req.Slug)).FirstOrDefault();

            if (page == null)
                await SendNotFoundAsync();
            else
                await SendAsync(new PageResponse(page));
        }
    }
}
