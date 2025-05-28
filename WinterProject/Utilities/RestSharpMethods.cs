using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WinterProject.Utilities
{
    public static class RestSharpMethods
    {

        public static RestClient client;
        public static RestRequest request;
        //public static RestResponse response;
        public static string baseUrl = "https://reqres.in";
        

        public static RestClient SetUrl(string endpoint)
        {
            var url = baseUrl + endpoint;
            Console.WriteLine("Request URL: " + url);
            return client = new RestClient(url);
            
        }

        public static RestRequest createRequest()
        {
            request = new RestRequest("endpoint",Method.Get);
            request.AddHeader("x-api-key", "reqres-free-v1");
            request.AddHeader("Accept", "application/json");
            return request;
        }

        public static RestResponse GetResponse()
        {
            return client.Execute(request);
        }
    }
}
