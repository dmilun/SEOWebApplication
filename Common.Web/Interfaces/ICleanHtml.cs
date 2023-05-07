using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Web.Interface
{
    /// <summary>
    /// This interface will be used to create classes to clean and sanatize html.
    /// </summary>
    public interface ICleanHtml
    {
        string RemoveScriptTagsFromHtmlString(string Html);
        string RemoveStyleTagsFromHtmlString(string Html);
    }
}
