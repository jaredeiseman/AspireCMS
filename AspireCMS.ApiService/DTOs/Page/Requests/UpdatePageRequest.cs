using System.Runtime.CompilerServices;

namespace AspireCMS.ApiService.DTOs.Page.Requests
{
    public class UpdatePageRequest
    {
        public Guid PageId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public bool IsPublished { get; set; }

        public Entities.Page ConvertToPage()
        {
            return new Entities.Page()
            {
                PageId = this.PageId,
                Title = this.Title,
                Slug = this.Slug,
                IsPublished = this.IsPublished,
                UpdatedDate = DateTime.Now
            };
        }
    }
}
