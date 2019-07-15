using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core
{
    class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;

        public HtmlLoader(IParserSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseURL}/{settings.Prefix}/{settings.University}/";
        }

        public async Task<string> GetSourceByPageId(int id)
        {
            string currentUrl = url + "?page=" + id.ToString();
            var responce = await client.GetAsync(currentUrl);
            string source = null;
            if (responce != null && responce.StatusCode == HttpStatusCode.OK) 
            {
                source = await responce.Content.ReadAsStringAsync();
            }
            return source;
        }
    }
}
