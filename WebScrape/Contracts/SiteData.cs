using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScrape.Contracts
{
    public class SiteData
    {
        public string URL { get; set; }
        public string Body { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }
    }
}
