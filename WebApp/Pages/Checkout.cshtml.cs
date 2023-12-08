using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json.Nodes;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MySqlX.XDevAPI;
using IdentityServer4.Models;
using System.Net.Http.Formatting;

namespace WebApp.Pages
{
    [IgnoreAntiforgeryToken]
    public class CheckoutModel : PageModel
    {
        public string PaypalClientId { get; set; } = "";
        private string PaypalSecret { get; set; } = "";
        public string PaypalUrl { get; set; } = "";



        public string Total { get; set; } = "";
        public string PackageIdentifiers { get; set; } = "";

        public CheckoutModel(IConfiguration configuration)
        {
            PaypalClientId = configuration["PaypalSettings:ClientId"]!;
            PaypalSecret = configuration["PaypalSettings:Secret"]!;
            PaypalUrl = configuration["PaypalSettings:Url"]!;
        }

        public class Service
        {
            public int IdService { get; set; }
            public float Cost { get; set; }

            public string? ServiceName { get; set; }

            public string? Description { get; set; }

            public int Availability { get; set; }
        }

        //Llamado a APIweb
       
        static HttpClient client = new HttpClient();

        static void ShowItem(Service service)
        {
            Console.WriteLine($"{service.Cost}");
        }

        static async Task<Uri> CreateItemAsync(Service service)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/Service", service);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }


        static async Task<Service> GetItemAsync(string path)
        {
            Service service = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                service = await response.Content.ReadAsAsync<Service>();
            }
            return service;
        }
            
        static async Task<Service> UpdateProductAsync(Service service)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/Service/{service.IdService}", service);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            service = await response.Content.ReadAsAsync<Service>();
            return service;
        }
            
            
        static async Task<HttpStatusCode> DeleteProductAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/Service/{id}");
            return response.StatusCode;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }
                
        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://localhost:7298/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new item
                Service service = new Service
                {
                    IdService = 123,
                    Cost = 100,
                    ServiceName = "Peluquería",
                    Description = "Corte de pelo extremo",
                    Availability = 2

                };

                var url = await CreateItemAsync(service);
                Console.WriteLine($"Created at {url}");
                
            // Get the product
            service = await GetItemAsync(url.PathAndQuery);
            ShowItem(service);

            // Update the product
            Console.WriteLine("Updating cost...");
            service.Cost = 80;
            await UpdateProductAsync(service);

            // Get the updated product
            service = await GetItemAsync(url.PathAndQuery);
            ShowItem(service);

              
                // Delete the product
                var statusCode = await DeleteProductAsync(service.IdService);
                Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");
                    

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        static async Task ReadAsAsync<Service>()
        {
            var formatters = new List<MediaTypeFormatter>() {
                //new MyCustomFormatter(),
                new JsonMediaTypeFormatter(),
                new XmlMediaTypeFormatter()
            };
          // resp.Content.ReadAsAsync<IEnumerable<Service>>(formatters);
        }


        public void OnGet( Service service)
        {

            Total = Convert.ToString(service.Cost); 
            
            //Total = TempData["Total"]?.ToString() ?? "";
            PackageIdentifiers = TempData["PackageIdentifiers"]?.ToString() ?? "";

            TempData.Keep();

            /*if (DeliveryAddress == "" || Total == "" || ProductIdentifiers == "")
            {
                Response.Redirect("/");
                return;
            }*/
        }

        public JsonResult OnPostCreateOrder(Service service )
        {
            //DeliveryAddress = TempData["DeliveryAddress"]?.ToString() ?? "";
            Total = Convert.ToString(service.Cost);

            //Total = TempData["Total"]?.ToString() ?? "";
            PackageIdentifiers = TempData["PackageIdentifiers"]?.ToString() ?? "";

            TempData.Keep();

            /* if (DeliveryAddress == "" || Total == "" || ProductIdentifiers == "")
             {
                 return new JsonResult("");
             }*/


            // create the request body
            JsonObject createOrderRequest = new JsonObject();
            createOrderRequest.Add("intent", "CAPTURE");

            JsonObject amount = new JsonObject();
            amount.Add("currency_code", "USD");
            amount.Add("value", Total);

            JsonObject purchaseUnit1 = new JsonObject();
            purchaseUnit1.Add("amount", amount);

            JsonArray purchaseUnits = new JsonArray();
            purchaseUnits.Add(purchaseUnit1);

            createOrderRequest.Add("purchase_units", purchaseUnits);


            // get access token
            string accessToken = GetPaypalAccessToken();


            // send request
            string url = PaypalUrl + "/v2/checkout/orders";

            string orderId = "";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Content = new StringContent(createOrderRequest.ToString(), null, "application/json");

                var responseTask = client.SendAsync(requestMessage);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var strResponse = readTask.Result;
                    var jsonResponse = JsonNode.Parse(strResponse);
                    if (jsonResponse != null)
                    {
                        orderId = jsonResponse["id"]?.ToString() ?? "";

                        // save the order in the database
                    }
                }
            }


            var response = new
            {
                Id = orderId
            };
            return new JsonResult(response);
        }


        public JsonResult OnPostCompleteOrder([FromBody] JsonObject data)
        {
            if (data == null || data["orderID"] == null) return new JsonResult("");

            var orderID = data["orderID"]!.ToString();


            // get access token
            string accessToken = GetPaypalAccessToken();


            string url = PaypalUrl + "/v2/checkout/orders/" + orderID + "/capture";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Content = new StringContent("", null, "application/json");

                var responseTask = client.SendAsync(requestMessage);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var strResponse = readTask.Result; Console.WriteLine("Paypal complete order success - response: " + strResponse);

                    var jsonResponse = JsonNode.Parse(strResponse);
                    if (jsonResponse != null)
                    {
                        string paypalOrderStatus = jsonResponse["status"]?.ToString() ?? "";
                        if (paypalOrderStatus == "COMPLETED")
                        {
                            // clear TempData
                            TempData.Clear();

                            // update payment status in the database => "accepted"

                            // clear cookie


                            return new JsonResult("success");
                        }
                    }
                }
            }

            return new JsonResult("");
        }


        public JsonResult OnPostCancelOrder([FromBody] JsonObject data)
        {
            if (data == null || data["orderID"] == null) return new JsonResult("");

            var orderID = data["orderID"]!.ToString();

            // update payment status in the database => "canceled"


            return new JsonResult("");
        }


        private string GetPaypalAccessToken()
        {
            string accessToken = "";

            string url = PaypalUrl + "/v1/oauth2/token";

            using (var client = new HttpClient())
            {
                string credentials64 =
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(PaypalClientId + ":" + PaypalSecret));

                client.DefaultRequestHeaders.Add("Authorization", "Basic " + credentials64);

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Content = new StringContent("grant_type=client_credentials", null
                    , "application/x-www-form-urlencoded");

                var responseTask = client.SendAsync(requestMessage);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    var strResponse = readTask.Result;

                    var jsonResponse = JsonNode.Parse(strResponse);
                    if (jsonResponse != null)
                    {
                        accessToken = jsonResponse["access_token"]?.ToString() ?? "";
                    }
                }
            }
            Console.WriteLine("JWT: " + accessToken);
            return accessToken;
        }

    }
}