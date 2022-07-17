using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace obsidian
{
    public class ApiClient
    {
        public static object SendRequest(string method, string url, object data = null, bool convert = true)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = null;
            Task<HttpResponseMessage> reqTask = null;
            StringContent content = null;

            if (data != null)
            {
                if (!(data is string))
                    content = new StringContent(JsonConvert.SerializeObject(data));
                else
                    content = new StringContent((string)data);
            }
            else
            {
                if (method == "POST")
                {
                    data = new { };
                }
            }

            switch (method)
            {
                case "GET":
                    reqTask = client.GetAsync(url);
                    break;
                case "POST":
                    reqTask = client.PostAsync(url, content);
                    break;
                default:
                    throw new Exception("Invalid method");
            }

            response = Utils.RunTaskSync<HttpResponseMessage>(reqTask);
            response.EnsureSuccessStatusCode();
            string respBody = Utils.RunTaskSync<string>(response.Content.ReadAsStringAsync());

            if (convert)
            {
                return JsonConvert.DeserializeObject(respBody);
            }
            else
            {
                return respBody;
            }
        }
    }
}
