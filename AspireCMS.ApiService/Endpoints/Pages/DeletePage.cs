using AspireCMS.ApiService.Contexts;
using AspireCMS.ApiService.DTOs.Page.Requests;
using AspireCMS.Entities;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace AspireCMS.ApiService.Endpoints.Pages
{
    [AllowAnonymous]
    [HttpDelete("/api/page/{PageId}")]
    public class DeletePage : Endpoint<DeletePageRequest>
    {
        public CMSContext Context { get; set; }

        public override async Task HandleAsync(DeletePageRequest req, CancellationToken ct)
        {
            Page pageToDelete = await Context.Pages.FindAsync(req.PageId, ct);

            if (pageToDelete == null)
            {
                await SendNotFoundAsync();
            }
            else
            {
                Context.Pages.Remove(pageToDelete);
                await Context.SaveChangesAsync();

                await SendNoContentAsync();
            }
        }
    }
}
