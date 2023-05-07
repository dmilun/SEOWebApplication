using Common.Web.Interface;

namespace Common.Web
{
    /// <summary>
    /// This abstract class will be used to create more Scraping object as the need arises
    /// </summary>
    public abstract class ScrapeHtml : IScrapeHtml
    {
        public abstract List<string> GetList(string html);
    }
}