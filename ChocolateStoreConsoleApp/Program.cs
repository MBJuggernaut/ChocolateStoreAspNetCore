using System.Net.Http;
using System;
using System.Threading.Tasks;
using ChocolateStoreClassLibrary.Models;
using System.Net.Http.Headers;

namespace ChocolateStoreConsoleApp
{
    class Program
    {
        private static HttpClient client = new HttpClient();
        static void Main()
        {
            Get().Wait();
        }

        public static async Task Get()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("https://localhost:44395/api/Items");
            if (response.IsSuccessStatusCode)
            {
                var sites = await response.Content.ReadAsStringAsync();
            }

            Console.WriteLine();
        }
    }
}
