using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAPI.API
{
    public class Api
    {
        private string Key { get; set; }

        private string Region { get; set; }

        public Api(string region)
        {
            Region = region;

            Key = GetKey("key.txt");
        }

        protected HttpResponseMessage GET (string url)
        {
            using(HttpClient client = new HttpClient())
            {
                var result = client.GetAsync(url);
                result.Wait();

                return result.Result;
            }
        }

        protected string GetURI(string path)
        {
            return "https://"+ Region +".api.riotgames.com/lol"+ path +"?api_key=" + Key;
        }

        public string GetKey(string path)
        {
            StreamReader sr = new StreamReader(path);

            return sr.ReadToEnd();
        }
    }
}
