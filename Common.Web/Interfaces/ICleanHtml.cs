using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Web.Interface
{
    public interface ICleanHtml
    {
        string RemoveScriptTagsFromHtmlString(string Html);
        string RemoveStyleTagsFromHtmlString(string Html);
    }
}
