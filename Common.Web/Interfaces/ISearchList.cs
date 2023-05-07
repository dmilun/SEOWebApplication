using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Web.Interface
{
    /// <summary>
    /// This interface will be used to implement a search class, that will loop through a list of strings and return a string result.
    /// </summary>
    public interface ISearchList
    {
        public string GetResults(string searchString, List<string> items);
    }
}
