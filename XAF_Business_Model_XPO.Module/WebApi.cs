using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using XAF_Business_Model_XPO.Module.Controllers;
using System.Net.Http;

namespace XAF_Business_Model_XPO.Module
{
    public class WebApi
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
    /*
    class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowProduct(WebApi product)
        {
            Console.WriteLine($"Name: {product.Name}\tPrice: " +
                $"{product.Price}\tCategory: {product.Category}");
        }

        static async Task<Uri> CreateProductAsync(WebApi product)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/products", product);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<WebApi> GetProductAsync(string path)
        {
            WebApi product = null;
            HttpResponseMessage response = await client.GetAsync("https://wl-api.mf.gov.pl//api/search/nip/" + NIP + "?date=" + DateTime.Now.Date.ToString());
            if (response.IsSuccessStatusCode)
            {
                //product = await response.Content.ReadAsStringAsync<WebApi>();
            }
           
            //string requestAddress = "https://wl-api.mf.gov.pl//api/search/nip/" + NIP + "?date=" + DateTime.Now.Date.ToString();

            //string response = await httpClient.GetStringAsync(requestAddress);
            //Console.WriteLine("https://wl-api.mf.gov.pl//api/search/nip/" + NIP + "?date=" + DateTime.Now.ToString("yyyy-MM-dd"));

            return product;
        }

        static async Task<WebApi> UpdateProductAsync(WebApi product)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/products/{product.Id}", product);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            //product = await response.Content.ReadAsAsync<WebApi>();
            return product;
        }

        static async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/products/{id}");
            return response.StatusCode;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new product
                WebApi product = new WebApi
                {
                    Name = "Gizmo",
                    Price = 100,
                    Category = "Widgets"
                };

                var url = await CreateProductAsync(product);
                Console.WriteLine($"Created at {url}");

                // Get the product
                product = await GetProductAsync(url.PathAndQuery);
                ShowProduct(product);

                // Update the product
                Console.WriteLine("Updating price...");
                product.Price = 80;
                await UpdateProductAsync(product);

                // Get the updated product
                product = await GetProductAsync(url.PathAndQuery);
                ShowProduct(product);

                // Delete the product
                var statusCode = await DeleteProductAsync(product.Id);
                Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
    */
}
