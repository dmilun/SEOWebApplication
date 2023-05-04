using Common.Web;
using Common.Web.HttpClients;
using Common.Web.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IScrapeHtml _scrapeHtml;
        private IGoogleSearchService _googleSearchService;
        public HomeController(ILogger<HomeController> logger, IScrapeHtml scrapeHtml, IGoogleSearchService googleSearchService)
        {
            _logger = logger;
            _scrapeHtml = scrapeHtml;
            _googleSearchService = googleSearchService;
        }

        public IActionResult Index()
        {
            //var html = _googleSearchService.GetSearchResultsAsHtmlString("efiling integration");
            //var result = _scrapeHtml.GetListOfResults(html, "www.infotrack.com");

            return View();
        }
        [HttpGet()]
        public JsonResult GetSearchResults(string keyWords, string urlSearch, int numOfSearchResults)
        {
            //Need to do a santy check here as well, check for null values and return error message.
            var topResults = 100;
            if (numOfSearchResults > 0 && numOfSearchResults <= 100)
            {
                topResults = numOfSearchResults;
            }
            var html = _googleSearchService.GetSearchResultsAsHtmlString(keyWords, topResults);
            var result = _scrapeHtml.GetListOfResults(html, urlSearch);

            return Json(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}