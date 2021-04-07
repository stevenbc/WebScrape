using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebScrape.Contracts;

namespace WebScrape
{
    public class SiteAsString
    {
        HttpClient _HttpClient;

        public SiteAsString()
        {
            _HttpClient = new HttpClient();
        }
        public async Task<SiteData> GetSiteData(string Url)
        {
            var siteData = await GetPageDataFromUrl(Url);
            return siteData;
        }

        async Task<SiteData>  GetPageDataFromUrl(string url)
        {
            var response = await _HttpClient.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            var statusCode = response.StatusCode;
            var errorMessage = string.IsNullOrEmpty(response.ReasonPhrase)? "" : response.ReasonPhrase;
            SiteData siteData = new SiteData()
            {
                Body = body,
                StatusCode = (int)statusCode,
                ErrorMessage = errorMessage,
                URL = url
            };

            return siteData;
        }

        private Uri GetRequestUri(HttpRequest request)
        {
            var builder = new UriBuilder()
            {
                Path = request.Path,
                Host = request.Host.Host,
                Query = request.QueryString.Value,
            };

            if (request.Host.Port.HasValue)
                builder.Port = request.Host.Port.Value;

            return builder.Uri;
        }


    }
}
