using AspireCMS.ApiService.Contexts;
using AspireCMS.ApiService.DTOs.Page.Responses;
using AspireCMS.Entities;
using AspireCMS.Interfaces;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace AspireCMS.ApiService.Endpoints.Pages
{
    [AllowAnonymous]
    [HttpGet("/api/pages")]
    public class GetPages : EndpointWithoutRequest<PagesResponse>
    {
        private IPageService _pageService;

        public GetPages(IPageService pageService)
        {
            _pageService = pageService;
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            List<Page> pages = _pageService.GetAllPages();

            if (pages == null || pages.Count == 0)
                await SendNotFoundAsync();
            else
                await SendAsync(new PagesResponse(pages));
        }
    }
}
