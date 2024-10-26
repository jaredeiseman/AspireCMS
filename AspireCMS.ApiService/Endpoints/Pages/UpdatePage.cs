using AspireCMS.ApiService.Contexts;
using AspireCMS.ApiService.DTOs.Page.Requests;
using AspireCMS.ApiService.DTOs.Page.Responses;
using AspireCMS.Entities;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace AspireCMS.ApiService.Endpoints.Pages
{
    [AllowAnonymous]
    [HttpPut("/api/page/{PageId}")]
    public class UpdatePage : Endpoint<UpdatePageRequest, PageResponse>
    {
        public CMSContext Context { get; set; }

        public override async Task HandleAsync(UpdatePageRequest request, CancellationToken ct)
        {
            Page pageToUpdate = await Context.Pages.FindAsync(request.PageId, ct);

            if (pageToUpdate != null)
            {
                pageToUpdate.Slug = request.Slug;
                pageToUpdate.Title = request.Title;
                pageToUpdate.IsPublished = request.IsPublished;
                pageToUpdate.UpdatedDate = DateTime.Now;

                await Context.SaveChangesAsync();

                await SendAsync(new PageResponse(pageToUpdate));
            }
            else
            {
                await SendNotFoundAsync();
            }
        }
    }
}
