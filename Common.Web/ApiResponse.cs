using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Web
{
    /// <summary>
    /// This is a class that is used for setting up consitant responses for our endpoints when they return data
    /// </summary>
    public class ApiResponse
    {
        public ApiResponse()
        {
            ErrorMessages = new List<string>();
            HasErrors = false;
        }
        public int HttpStatusCode { get; set; }
        public bool HasErrors { get; set; }
        public object? Data { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
