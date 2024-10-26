namespace AspireCMS.ApiService.DTOs.Page.Responses
{
    public class PageResponse
    {
        public Guid PageId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsPublished { get; set; }

        public PageResponse(Entities.Page page)
        {
            PageId = page.PageId;
            Title = page.Title;
            Slug = page.Slug;
            CreatedDate = page.CreatedDate;
            UpdatedDate = page.UpdatedDate;
            IsPublished = page.IsPublished;
        }
    }
}
