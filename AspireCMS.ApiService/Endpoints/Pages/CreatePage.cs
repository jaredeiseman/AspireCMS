using AspireCMS.ApiService.Contexts;
using AspireCMS.ApiService.DTOs.Page.Requests;
using AspireCMS.Entities;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace AspireCMS.ApiService.Endpoints.Pages
{
    [AllowAnonymous]
    [HttpPost("/api/page")]
    public class CreatePage : Endpoint<CreatePageRequest>
    {
        public CMSContext Context { get; set; }

        public override async Task HandleAsync(CreatePageRequest req, CancellationToken ct)
        {
            Page newPage = new Page() { Title = req.Title, Slug = req.Slug };
            
            Context.Pages.Add(newPage);
            
            await Context.SaveChangesAsync();
            
            await SendAsync(newPage);
        }
    }
}
