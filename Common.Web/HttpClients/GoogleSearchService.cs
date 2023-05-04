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
        private readonly string _BaseUrl = "https://www.google.com/";

        public GoogleSearchService(HttpClient httpClient)
        {
            _httpClient = httpClient;            
        }
        /// <summary>
        /// This is a synchronous call to the Google Webpage using the HTTP client to get the HTML and remove the scripts and style information.
        /// </summary>
        /// <param name="keyWords"></param>
        /// <param name="topResults"></param>
        /// <returns></returns>
        public string GetSearchResultsAsHtmlString(string keyWords, int topResults = 100)
        {
            return GetSearchResultsAsHtmlStringAsync(keyWords, topResults).Result;
        }

        /// <summary>
        /// This is a asynchronous call to the Google Webpage using the HTTP client to get the HTML and remove the scripts and style information.
        /// </summary>
        /// <param name="keyWords"></param>
        /// <param name="topResults"></param>
        /// <returns></returns>
        public async Task<string> GetSearchResultsAsHtmlStringAsync(string keyWords, int topResults = 100)
        {
            var response = await _httpClient.GetAsync(BuildSearchUrl(keyWords, topResults));
            
            response.EnsureSuccessStatusCode(); //This will make sure our requst was succesful if not it will throw an exception

            var content = response.Content;
            var result = content.ReadAsStringAsync().Result;

            return result;
        }

        /// <summary>
        /// This will build the URL that will be passed via the HTTP client
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="topResults"></param>
        /// <returns></returns>
        private string BuildSearchUrl(string keywords,  int topResults) 
        {
            //Ex: https://www.google.com/search?num=100&q=efiling+integration
            return $"{_BaseUrl}search?num={topResults}&q={System.Web.HttpUtility.UrlEncode(keywords)}";
        }
    }
}
