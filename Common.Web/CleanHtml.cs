using Common.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Web
{
    /// <summary>
    /// This class is used to help remove sections from the HTML file to make it smaller for searching and allow for using css classes and prevent false positives.
    /// </summary>
    public class CleanHtml : ICleanHtml
    {
        /// <summary>
        /// This method will take a HTML string and remove all the scripts tags and content inbetween from it.
        /// </summary>
        /// <param name="Html"></param>
        /// <returns>cleaned HTML string</returns>
        public string RemoveScriptTagsFromHtmlString(string Html)
        {
            Regex rRemScript = new(@"<script[^>]*>[\s\S]*?</script>");
            var output = rRemScript.Replace(Html, "");
            return output;
        }

        /// <summary>
        /// This method will take a HTML string and remove all the style tags and content inbetween from it.
        /// </summary>
        /// <param name="Html"></param>
        /// <returns>cleaned HTML string</returns>
        public string RemoveStyleTagsFromHtmlString(string Html)
        {
            Regex rRemStyle = new(@"<style[^>]*>[\s\S]*?</style>");
            var output = rRemStyle.Replace(Html, "");
            return output;
        }
    }
}
