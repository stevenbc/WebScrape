using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScrape.Contracts;
using WebScrape;
namespace ScrapeApi.Controllers
{
    [Route("api/[[WebScrape]]")]
    [Controller]
    public class WebScrapeController : ControllerBase
    {
        //[HttpGet]
        //public async Task<List<SiteData>> ScrapeOneWebSite(string url)
        //{
        //    List<string> urls = new List<string>();
        //    urls.Add(url);

        //    Scrape scrape = new Scrape();
        //    var data = scrape.GetSites(urls);
        //    return data;
        //}

        [HttpGet]
        public async Task<List<SiteData>> ScrapeSites(string[] urls)
        {
            Scrape scrape = new Scrape();
            var data = scrape.GetSites(urls.ToList());
            return data;
        }
    }
}
