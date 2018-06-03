using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services
{
    class DataService
    {
        public async static Task<dynamic> GetDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            try
            {
                var response = await client.GetAsync(queryString);

                if (response != null)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    dynamic data = JsonConvert.DeserializeObject(json);
                    return data;
                }

                return null;
            }
            catch (HttpRequestException e)
            {
                Console.Write("Source : ");
                Console.WriteLine(e.InnerException.Source);
                Console.Write("Message : ");
                Console.WriteLine(e.InnerException.Message);
                Console.Write("HResult : ");
                Console.WriteLine(e.InnerException.HResult);

            }
            return null;
        }

        public async static Task<bool> PostDataToService(TodoItem item, string queryString)
        {
            HttpClient client = new HttpClient();

            var stringJson = JsonConvert.SerializeObject(item);
            HttpContent content = new StringContent(stringJson, Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync(queryString, content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                return false;
            }
            catch (HttpRequestException e)
            {
                Console.Write("Source : ");
                Console.WriteLine(e.InnerException.Source);
                Console.Write("Message : ");
                Console.WriteLine(e.InnerException.Message);
                Console.Write("HResult : ");
                Console.WriteLine(e.InnerException.HResult);

            }
            return false;
        }

        public async static Task<bool> PutDataToService(TodoItem item, string queryString)
        {
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(item);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PutAsync(queryString, content);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                return false;
            }
            catch (HttpRequestException e)
            {
                Console.Write("Source : ");
                Console.WriteLine(e.InnerException.Source);
                Console.Write("Message : ");
                Console.WriteLine(e.InnerException.Message);
                Console.Write("HResult : ");
                Console.WriteLine(e.InnerException.HResult);

            }

            return false;
        }
    }
}
