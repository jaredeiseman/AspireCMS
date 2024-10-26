using AspireCMS.Entities;

namespace AspireCMS.Interfaces
{
    public interface IPageService
    {
        /// <summary>
        /// Create a new page.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="slug"></param>
        /// <returns></returns>
        Task<Page> CreatePage(string title, string slug);

        /// <summary>
        /// Delete a page by page ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<bool> DeletePage(Guid id, CancellationToken? ct = null);

        /// <summary>
        /// Get all pages.
        /// </summary>
        /// <returns></returns>
        List<Page> GetAllPages();

        /// <summary>
        /// Get page by slug.
        /// </summary>
        /// <param name="slug"></param>
        /// <returns></returns>
        Page? GetPage(string slug);

        /// <summary>
        /// Update a page.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Page?> UpdatePage(Page page, CancellationToken? ct = null);
    }
}