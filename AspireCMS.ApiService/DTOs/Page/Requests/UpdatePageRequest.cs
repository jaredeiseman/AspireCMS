namespace AspireCMS.ApiService.DTOs.Page.Requests
{
    public class UpdatePageRequest
    {
        public Guid PageId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public bool IsPublished { get; set; }
    }
}
