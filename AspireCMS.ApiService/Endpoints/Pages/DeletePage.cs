using AspireCMS.ApiService.Contexts;
using AspireCMS.ApiService.DTOs.Page.Requests;
using AspireCMS.Entities;
using AspireCMS.Interfaces;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace AspireCMS.ApiService.Endpoints.Pages
{
    [AllowAnonymous]
    [HttpDelete("/api/page/{PageId}")]
    public class DeletePage : Endpoint<DeletePageRequest>
    {
        private IPageService _pageService;

        public DeletePage(IPageService pageService)
        {
            _pageService = pageService;
        }

        public override async Task HandleAsync(DeletePageRequest req, CancellationToken ct)
        {
            if (await _pageService.DeletePage(req.PageId, ct))
            {
                await SendNoContentAsync();
            }
            else
            {
                await SendNotFoundAsync();
            }
        }
    }
}
