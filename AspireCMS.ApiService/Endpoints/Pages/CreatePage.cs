using AspireCMS.ApiService.Contexts;
using AspireCMS.ApiService.DTOs.Page.Requests;
using AspireCMS.Entities;
using AspireCMS.Interfaces;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace AspireCMS.ApiService.Endpoints.Pages
{
    [AllowAnonymous]
    [HttpPost("/api/page")]
    public class CreatePage : Endpoint<CreatePageRequest>
    {
        public IPageService _pageService { get; set; }

        public CreatePage(IPageService pageService)
        {
            _pageService = pageService;
        }

        public override async Task HandleAsync(CreatePageRequest req, CancellationToken ct)
        {
            await SendAsync(await _pageService.CreatePage(req.Title, req.Slug));
        }
    }
}
