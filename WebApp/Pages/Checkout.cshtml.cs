using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json.Nodes;

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

        public void OnGet()
        {
            Total = "1111";
            System.Console.WriteLine("tempdata total= " + TempData["Total"]?.ToString() ?? "");
            //Total = TempData["Total"]?.ToString() ?? "";
            PackageIdentifiers = TempData["PackageIdentifiers"]?.ToString() ?? "";

            TempData.Keep();

            /*if (DeliveryAddress == "" || Total == "" || ProductIdentifiers == "")
            {
                Response.Redirect("/");
                return;
            }*/
        }

        public JsonResult OnPostCreateOrder()
        {
            //DeliveryAddress = TempData["DeliveryAddress"]?.ToString() ?? "";
            Total = "1111";

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