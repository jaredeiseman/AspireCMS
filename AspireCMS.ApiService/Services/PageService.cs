using AspireCMS.ApiService.Contexts;
using AspireCMS.Entities;
using AspireCMS.Interfaces;

namespace AspireCMS.ApiService.Services
{
    public class PageService : IPageService
    {
        private CMSContext _context;

        public PageService(CMSContext context)
        {
            _context = context;
        }

        public async Task<Page> CreatePage(string title, string slug)
        {
            Page newPage = new Page() { Title = title, Slug = slug };

            _context.Pages.Add(newPage);

            await _context.SaveChangesAsync();

            return newPage;
        }

        public Page? GetPage(string slug)
        {
            return _context.Pages.Where(p => p.Slug.Equals(slug)).FirstOrDefault();
        }

        public List<Page> GetAllPages()
        {
            return [.. _context.Pages];
        }

        public async Task<Page?> UpdatePage(Page page, CancellationToken? ct = null)
        {
            Page? pageToUpdate = await _context.Pages.FindAsync(page.PageId, ct ?? CancellationToken.None);

            if (pageToUpdate != null)
            {
                pageToUpdate.Slug = page.Slug;
                pageToUpdate.Title = page.Title;
                pageToUpdate.IsPublished = page.IsPublished;
                pageToUpdate.UpdatedDate = DateTime.Now;

                await _context.SaveChangesAsync();
            }

            return pageToUpdate;
        }

        public async Task<bool> DeletePage(Guid id, CancellationToken? ct = null)
        {
            Page? pageToDelete = await _context.Pages.FindAsync(id, ct);

            if (pageToDelete != null)
            {
                _context.Pages.Remove(pageToDelete);
                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
