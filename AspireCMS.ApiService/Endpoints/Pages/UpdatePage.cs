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
    [HttpPut("/api/page/{PageId}")]
    public class UpdatePage : Endpoint<UpdatePageRequest, PageResponse>
    {
        private IPageService _pageService;

        public UpdatePage(IPageService pageService)
        {
            _pageService = pageService;
        }

        public override async Task HandleAsync(UpdatePageRequest request, CancellationToken ct)
        {
            Page? updatedPage = await _pageService.UpdatePage(request.ConvertToPage());

            if (updatedPage != null)
            {
                await SendAsync(new PageResponse(updatedPage));
            }
            else
            {
                await SendNotFoundAsync();
            }
        }
    }
}
