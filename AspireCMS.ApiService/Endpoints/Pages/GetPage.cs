using AspireCMS.ApiService.Contexts;
using AspireCMS.ApiService.DTOs.Page.Requests;
using AspireCMS.ApiService.DTOs.Page.Responses;
using AspireCMS.Entities;
using AspireCMS.Interfaces;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace AspireCMS.ApiService.Endpoints.Pages
{
    [AllowAnonymous]
    [HttpGet("/api/page")]
    public class GetPage : Endpoint<PageRequest, PageResponse>
    {
        private IPageService _pageService;

        public GetPage(IPageService pageService)
        {
            _pageService = pageService;
        }

        public override async Task HandleAsync(PageRequest req, CancellationToken ct)
        {
            Page? page = _pageService.GetPage(req.Slug);

            if (page == null)
                await SendNotFoundAsync();
            else
                await SendAsync(new PageResponse(page));
        }
    }
}
