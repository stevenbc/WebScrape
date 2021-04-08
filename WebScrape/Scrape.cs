using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebScrape.Contracts;
namespace WebScrape
{
    public class Scrape
    {
        public List<SiteData> GetSites(List<string> webPages)
        {
            var data = new List<SiteData>();
            var taskList = new List<Task<SiteData>>();
            SiteAsString siteAsString = new SiteAsString();
            
            foreach(var webpage in webPages)
            {
                Task<SiteData > lastTask = siteAsString.GetSiteData(webpage);
                taskList.Add(lastTask);
            }

            Task.WaitAll(taskList.ToArray());
            
            foreach(var res in taskList)
            {
                data.Add(res.Result);
            }
            return data ;
        }
    }
}
