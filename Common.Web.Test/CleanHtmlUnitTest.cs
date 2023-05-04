using static System.Net.Mime.MediaTypeNames;

namespace Common.Web.Test
{
    public class CleanHtmlUnitTest
    {
        /// <summary>
        /// This test will check to make sure the html script tags are removed. I pass in 4 types of sample HTML
        /// 1 - With style and script tags
        /// 1 - With style and no script tags
        /// 1 - With no style and script tags
        /// 1 - With no style or script tags
        /// </summary>
        /// <param name="html"></param>
        [Theory]
        [InlineData("<!DOCTYPE html><html><style>test</style><body><h1>My First Heading</h1><p>My first paragraph.</p><script type='text/javascript' src='theJs.js'></script></body></html>")]
        [InlineData("<!DOCTYPE html><html><style>test</style><body><h1>My First Heading</h1><p>My first paragraph.</p></body></html>")]
        [InlineData("<!DOCTYPE html><html><body><h1>My First Heading</h1><p>My first paragraph.</p><script type='text/javascript' src='theJs.js'></script></body></html>")]
        [InlineData("<!DOCTYPE html><html><body><h1>My First Heading</h1><p>My first paragraph.</p></body></html>")]
        public void RemoveScriptTagsFromHtmlStringTest(string html)
        {
            //Arrange 
            var cleanHtml = new CleanHtml();

            //Act
            var output = cleanHtml.RemoveScriptTagsFromHtmlString(html);
            var scriptDoesNotExisit = output.Contains("<script>");

            //Assert 
            Assert.False(scriptDoesNotExisit);
        }

        /// <summary>
        /// This test will check to make sure the html style tags are removed. I pass in 4 types of sample HTML
        /// 1 - With style and script tags
        /// 1 - With style and no script tags
        /// 1 - With no style and script tags
        /// 1 - With no style or script tags
        /// </summary>
        /// <param name="html"></param>
        [Theory]
        [InlineData("<!DOCTYPE html><html><style>test</style><body><h1>My First Heading</h1><p>My first paragraph.</p><script type='text/javascript' src='theJs.js'></script></body></html>")]
        [InlineData("<!DOCTYPE html><html><style>test</style><body><h1>My First Heading</h1><p>My first paragraph.</p></body></html>")]
        [InlineData("<!DOCTYPE html><html><body><h1>My First Heading</h1><p>My first paragraph.</p><script type='text/javascript' src='theJs.js'></script></body></html>")]
        [InlineData("<!DOCTYPE html><html><body><h1>My First Heading</h1><p>My first paragraph.</p></body></html>")]
        public void RemoveStyleTagsFromHtmlStringTest(string html)
        {
            //Arrange 
            var cleanHtml = new CleanHtml();

            //Act
            var output = cleanHtml.RemoveStyleTagsFromHtmlString(html);
            var styleDoesNotExisit = output.Contains("<style>");

            //Assert 
            Assert.False(styleDoesNotExisit);
        }
    }
}