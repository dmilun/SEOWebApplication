using Common.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Web
{
    public class CleanHtml : ICleanHtml
    {
        public string RemoveScriptTagsFromHtmlString(string Html)
        {
            Regex rRemScript = new Regex(@"<script[^>]*>[\s\S]*?</script>");
            var output = rRemScript.Replace(Html, "");
            return output;
        }

        public string RemoveStyleTagsFromHtmlString(string Html)
        {
            Regex rRemStyle = new Regex(@"<style[^>]*>[\s\S]*?</style>");
            var output = rRemStyle.Replace(Html, "");
            return output;
        }
    }
}
