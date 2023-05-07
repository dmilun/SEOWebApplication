using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Web.HttpClients
{
    /// <summary>
    /// This interface will be used to create the HTTP client to connect to google search
    /// </summary>
    public interface IGoogleSearchService
    {
        string GetSearchResultsAsHtmlString(string keyWords, int topResults = 100);
        Task<string> GetSearchResultsAsHtmlStringAsync(string keyWords, int topResults = 100);
    }
}
