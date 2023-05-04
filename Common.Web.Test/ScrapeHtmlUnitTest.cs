using static System.Net.Mime.MediaTypeNames;

namespace Common.Web.Test
{
    public class ScrapeHtmlUnitTest
    {
        /// <summary>
        /// This test will read in a sample HTML file that does have search results and Hrefs and parse it based on the logic inside of ScrapeHtml and should find results
        /// </summary>
        [Fact]
        public void ScrapeHtmlUsingHrefTestWithSearchResults()
        {
            //Arrange 
            var scrapeHtml = new ScrapeHtmlUsingHref();
            var filename = "./Resources/SampleGoogleSearch.html";
            var html = File.ReadAllText(filename);

            //Act
            var result = scrapeHtml.GetList(html);

            //Assert 
            Assert.True(result.Any());

        }
        /// <summary>
        /// This test will read in a sample HTML file that does not have any search results or Hrefs and parse it based on the logic inside of ScrapeHtml and should find nothing
        /// </summary>
        [Fact]
        public void ScrapeHtmlUsingHrefTestWithNoSearchResults()
        {
            //Arrange 
            var scrapeHtml = new ScrapeHtmlUsingHref();
            var filename = "./Resources/GoogleNoSearchResults.html";
            var html = File.ReadAllText(filename);

            //Act
            var result = scrapeHtml.GetList(html);

            //Assert 
            Assert.False(result.Any());

        }

    }
}