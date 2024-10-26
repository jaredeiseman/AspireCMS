namespace AspireCMS.ApiService.DTOs.Page.Responses
{
    public class PagesResponse
    {
        public List<Entities.Page> Pages { get; set; }

        public PagesResponse(List<Entities.Page> pages)
        {
            Pages = pages;
        }
    }
}
