using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Web.Interface
{
    public interface ISearchList
    {
        public string GetResults(string searchString, List<string> items);
    }
}
