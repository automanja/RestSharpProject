using APILibrary.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APILibrary
{
    public class APIHelper
    {
        public RestClient SetUri(string endpoint)
        {
            string baseUri = "https://reqres.in/";
            string uri = Path.Combine(baseUri, endpoint);
            return new RestClient(uri);
        }

        public RestRequest CreatePostRequest(string payload)
        {
            RestRequest request = new RestRequest(Method.POST);
            var dict = new Dictionary<string, string>
            {
                { "Accept", "application/json" }
            };
            request.AddHeaders(dict);
            request.AddParameter("application/json", payload, ParameterType.RequestBody);
            return request;
        }

        public RestRequest CreateGetRequest()
        {
            RestRequest request = new RestRequest(Method.GET);
            var dict = new Dictionary<string, string>
            {
                { "Accept", "application/json" }
            };
            request.AddHeaders(dict);
            return request;
        }

        public IRestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }

        public T GetContent<T>(IRestResponse response) where T : ICommonModel
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public string Serialize<T>(T request) where T : ICommonModel
        {
            return JsonConvert.SerializeObject(request);
        }
    }
}
