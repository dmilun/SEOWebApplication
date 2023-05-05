using Common.Web.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.Web
{
    public class SearchList : ISearchList
    {
        /// <summary>
        /// This method will take a search string and loop through the list of values and check to see if it contains that search string. 
        /// It if does, it will add that index plus 1 (output needs to be 1 based) to the results, if not, it will add 0, it will always pass back a List<int>.
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public string GetResults(string searchString, List<string> items)
        {
            var result = string.Empty;
            //var lstResults = new List<int>();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Contains(searchString))
                {
                    //lstResults.Add(i + 1); //Need to add 1 as the loop is zero based
                    result = result + $"{i + 1}, ";

                }
            }

            if (string.IsNullOrEmpty(result))
            {
                return "0";
            }
            ////If we did not find any results, return a zero
            //if (!lstResults.Any()) 
            //{ 
            //    lstResults.Add(0);
            //}

            return result.Substring(0, result.Length-2);
        }
    }
}
