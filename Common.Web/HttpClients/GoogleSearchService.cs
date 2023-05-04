using Common.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Web.HttpClients
{
    public class GoogleSearchService : IGoogleSearchService
    {
        private readonly HttpClient _httpClient;
        private readonly ICleanHtml _cleanHtml;
        private readonly string _BaseUrl = "https://www.google.com/";

        public GoogleSearchService(HttpClient httpClient, ICleanHtml cleanHtml)
        {
            _httpClient = httpClient;
            _cleanHtml = cleanHtml;
        }

        public string GetSearchResultsAsHtmlString(string keyWords, int topResults = 100)
        {
            return GetSearchResultsAsHtmlStringAsync(keyWords, topResults).Result;
        }

        public async Task<string> GetSearchResultsAsHtmlStringAsync(string keyWords, int topResults = 100)
        {
            var response = await _httpClient.GetAsync(BuildSearchUrl(keyWords, topResults));
            var content = response.Content;
            var result = content.ReadAsStringAsync().Result;

            var output = _cleanHtml.RemoveScriptTagsFromHtmlString(result);
            output = _cleanHtml.RemoveStyleTagsFromHtmlString(output);

            return output;
        }

        private string BuildSearchUrl(string keywords,  int topResults) 
        {
            //https://www.google.com/search?num=100&q=efiling+integration
            return $"{_BaseUrl}search?num={topResults}&q={System.Web.HttpUtility.UrlEncode(keywords)}";
        }
    }
}
