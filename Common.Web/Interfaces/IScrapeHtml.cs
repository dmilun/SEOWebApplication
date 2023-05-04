using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Web.Interface
{
    public interface IScrapeHtml
    {
        //This method will walk through the HTML string and based on a start indexof item and a end indexof item you will get a substring of the result.
        public List<string> GetList(string html);
    }
}
