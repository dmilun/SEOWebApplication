using Common.Web;
using Common.Web.HttpClients;
using Common.Web.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IScrapeHtml _scrapeHtml;
        private IGoogleSearchService _googleSearchService;
        private ISearchList _searchList;
        private readonly ICleanHtml _cleanHtml;
        
        //TODO: Setup a way to leverage the logger when there are issues.
        public HomeController(ILogger<HomeController> logger, 
            IScrapeHtml scrapeHtml, 
            IGoogleSearchService googleSearchService, 
            ISearchList searchList, 
            ICleanHtml cleanHtml)
        {
            _logger = logger;
            _scrapeHtml = scrapeHtml;
            _googleSearchService = googleSearchService;
            _searchList = searchList;
            _cleanHtml = cleanHtml;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet()]
        public ApiResponse GetSearchResults(string keyWords, string urlSearch, int numOfSearchResults)
        {
            var response= new ApiResponse();

            try
            {
                //This check will make sure all required fields are avaliable
                //Need to do a santy check here as well, check for null values and return error message.
                var errors = ValidateGetSearchResultsParams(keyWords, urlSearch, numOfSearchResults);
                if (errors.Any())
                {
                    response.HasErrors = true;
                    response.HttpStatusCode = (int)HttpStatusCode.BadRequest;
                    response.ErrorMessages = errors;
                    return response;
                }
                
                var topResults = 100;
                if (numOfSearchResults > 0 && numOfSearchResults <= 100)
                {
                    topResults = numOfSearchResults;
                }

                var html = _googleSearchService.GetSearchResultsAsHtmlString(keyWords, topResults);
                html = _cleanHtml.RemoveScriptTagsFromHtmlString(html);
                html = _cleanHtml.RemoveStyleTagsFromHtmlString(html);

                var lstResults = _scrapeHtml.GetList(html);

                var output = _searchList.GetResults(urlSearch, lstResults);

                response.HttpStatusCode = (int)HttpStatusCode.OK;
                response.Data = output;

                return response;
            }
            catch (Exception)
            {
                response.HasErrors= true;
                response.HttpStatusCode = (int)HttpStatusCode.InternalServerError;
                response.ErrorMessages = new List<string>() { "There was an issue with your request. Please try again."};
                return response;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private List<string> ValidateGetSearchResultsParams(string keyWords, string urlSearch, int numOfSearchResults)
        {
            var errorList = new List<string>();

            if (string.IsNullOrEmpty(keyWords))
            {
                errorList.Add("Missing Keywords");
            }
            if (string.IsNullOrEmpty(urlSearch))
            {
                errorList.Add("URL Search is missing");
            }
            if (numOfSearchResults > 100)
            {
                errorList.Add("Search results have to be less than or equal to 100.");
            }
            return errorList;
        }
    }
}