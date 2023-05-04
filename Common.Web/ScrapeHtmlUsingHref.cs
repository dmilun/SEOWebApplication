using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Web
{
    public class ScrapeHtmlUsingHref : ScrapeHtml
    {
        /// <summary>
        /// This method will take in a html string and walk through the string based on a starting and ending index and extract a substring which will be added to the results
        /// Future Enhancement: Can extend this to pass in the start and end search criteria.
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public override List<string> GetList(string html)
        {
            List<string> aElements = new();

            int index = 0;
            while (index < html.Length)
            {
                // Find the start and end index
                int start = html.IndexOf("href=\"/url?q=", index);

                if (start == -1) //Stop walking through the string once I can not find the string
                {
                    break;
                }
                int end = html.IndexOf(">", start);

                // TODO: might want to combime this
                var endSubString = end - (start + "href=\"/url?q=".Length);
                aElements.Add(html.Substring(start + "href=\"/url?q=".Length, endSubString));

                // Move the index past the end of the </div> tag
                index = end + "</div>".Length;
            }

            return aElements;
        }
    }
}
