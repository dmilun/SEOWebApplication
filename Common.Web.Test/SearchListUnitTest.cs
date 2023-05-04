using static System.Net.Mime.MediaTypeNames;

namespace Common.Web.Test
{
    public class SearchListUnitTest
    {
        /// <summary>
        /// This test will read in a sample HTML file that does have search results and Hrefs and parse it based on the logic inside of ScrapeHtml and should find results
        /// </summary>
        [Theory]
        [InlineData("www.infotrack.com", new int[] { 1, 2 })]
        [InlineData("www.onelegal.com", new int[] { 5 })]
        [InlineData("www.mycase.com", new int[] { 9 })]
        [InlineData("www.leap.us", new int[] { 8 })]
        public void SearchListForSpecificUrl(string Url, int[] actual)
        {
            var filename = "./Resources/SampleGoogleSearch.html";

            //Arrange 
            var searchList = new SearchList();
            var cleanHtml = new CleanHtml();
            var scrapeHtml = new ScrapeHtmlUsingHref();
            
            var htmlString = File.ReadAllText(filename);
            htmlString = cleanHtml.RemoveScriptTagsFromHtmlString(htmlString);
            htmlString = cleanHtml.RemoveStyleTagsFromHtmlString(htmlString);
            var items = scrapeHtml.GetList(htmlString);

            //Act
            var result = searchList.GetResults(Url, items);

            //Assert 
            Assert.Equal(result.ToArray(), actual);

        }
        /// <summary>
        /// This test will read in a sample HTML file that does have search results and Hrefs and parse it 
        /// based on the logic inside of ScrapeHtml and wil not find results as the URL does not exist
        /// </summary>
        [Theory]
        [InlineData("www.idonotexist.com", new int[] { 0 })]
        public void SearchListForSpecificUrlThatDoesNotExist(string Url, int[] actual)
        {
            var filename = "./Resources/SampleGoogleSearch.html";

            //Arrange 
            var searchList = new SearchList();
            var cleanHtml = new CleanHtml();
            var scrapeHtml = new ScrapeHtmlUsingHref();

            var htmlString = File.ReadAllText(filename);
            htmlString = cleanHtml.RemoveScriptTagsFromHtmlString(htmlString);
            htmlString = cleanHtml.RemoveStyleTagsFromHtmlString(htmlString);
            var items = scrapeHtml.GetList(htmlString);

            //Act
            var result = searchList.GetResults(Url, items);

            //Assert 
            Assert.Equal(result.ToArray(), actual);

        }
    }
}