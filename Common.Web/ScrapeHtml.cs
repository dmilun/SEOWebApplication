using Common.Web.Interface;

namespace Common.Web
{
    public class ScrapeHtml : IScrapeHtml
    {
        public List<int> GetListOfResults(string output, string searchString)
        {
            List<string> aElements = new();

            int index = 0;
            while (index < output.Length)
            {
                // Find the start and end index
                int start = output.IndexOf("href=\"/url?q=", index);
                
                if (start == -1) //Stop walking through the string once I can not find the string
                {
                    break;
                }
                int end = output.IndexOf(">", start);

                // TODO: might want to combime this
                var endSubString = end - (start + "href=\"/url?q=".Length);
                aElements.Add(output.Substring(start + "href=\"/url?q=".Length, endSubString));

                // Move the index past the end of the </div> tag
                index = end + "</div>".Length;
            }
            var lstResults = new List<int>();
            for (int i = 0; i < aElements.Count; i++)
            {
                if (aElements[i].Contains(searchString))
                {
                    lstResults.Add(i + 1); //Need to add 1 as the loop is zero based
                }
            }

            return lstResults;
        }
    }
}