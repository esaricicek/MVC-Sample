using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class OtherController : Controller
    {
        // GET: Other
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult User()
        {
            ViewBag.Message = "User Sayfası.";

            return View();
        }

        public ActionResult Payment()
        {

            var client = new RestClient("https://merchant-test.teqpay.com/api/teqpay/paywithcommonpage");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);

            request.AddHeader("ApiKey", "ligseM+7OpzjgTI3c/eoD7dWdazewJmSAIX2zeqSJUw=");
            request.AddHeader("SecretKey", "mHJEY8ak5hN2HHXIaa/FkKHuYDj69d+cFIDfNOVERuM=");
            request.AddHeader("Content-Type", "application/json");

            var x = "" +
                "{\"customerName\": \"Teqpay Test\"," +
                "\"customerCitizenNo\": \"12345678901\"," +
                "\"customerEmail\": \"demo@teqpay.com\"," +
                "\"customerPhone\": \"1234567890\"," +
                "\"customerIpAddress\": \"127.0.0.1\"," +
                "\"price\": 25.0," +
                "\"conversationId\": \"TP12345\"," +
                "\"callbackUrl\": \"https://www.test.com\"," +
                "\"language\": \"en\"," +
                "\"paymentMetodId\": null," +
                "\"installment\": [\"1\",\"3\",\"6\",\"9\"]," +
                "\"products\": " +
                "[{\"merchantItemId\": \"1\",\"itemType\": \"Test 1\",\"itemCategory\": \"Oyun\",\"itemName\": \"Pubg Mobile\",	\"itemQuantity\": 1,\"itemPrice\": 15.0}," +
                "{\"merchantItemId\": \"2\",\"itemType\": \"Test 2\",\"itemCategory\": \"Oyun\",\"itemName\": \"Zula Mobile\",\"itemQuantity\": 1,\"itemPrice\": 10.0}]," +
                "\"billing\": {\"billingName\": \"Teqpay Demo\",\"billingCity\": \"İstanbul\",\"billingCountry\": \"Türkiye\",\"billingAddress\": \"İstanbul\"}," +
                "\"shipping\": {\"shippingContactName\": \"Teqpay Demo\",\"shippingCity\": \"İstanbul\",\"shippingCountry\": \"Türkiye\",\"shippingAddress\": \"İstanbul\"}}";


            request.AddParameter("application/json", "" +
                "{\"customerName\": \"Teqpay Test\"," +
                "\"customerCitizenNo\": \"12345678901\"," +
                "\"customerEmail\": \"demo@teqpay.com\"," +
                "\"customerPhone\": \"1234567890\"," +
                "\"customerIpAddress\": \"127.0.0.1\"," +
                "\"price\": 25.0," +
                "\"conversationId\": \"TP12345\"," +
                "\"callbackUrl\": \"https://www.test.com\"," +
                "\"language\": \"en\"," +
                "\"paymentMetodId\": null," +
                "\"installment\": [\"1\",\"3\",\"6\",\"9\"]," +
                "\"products\": " +
                "[{\"merchantItemId\": \"1\",\"itemType\": \"Test 1\",\"itemCategory\": \"Oyun\",\"itemName\": \"Pubg Mobile\",	\"itemQuantity\": 1,\"itemPrice\": 15.0}," +
                "{\"merchantItemId\": \"2\",\"itemType\": \"Test 2\",\"itemCategory\": \"Oyun\",\"itemName\": \"Zula Mobile\",\"itemQuantity\": 1,\"itemPrice\": 10.0}]," +
                "\"billing\": {\"billingName\": \"Teqpay Demo\",\"billingCity\": \"İstanbul\",\"billingCountry\": \"Türkiye\",\"billingAddress\": \"İstanbul\"}," +
                "\"shipping\": {\"shippingContactName\": \"Teqpay Demo\",\"shippingCity\": \"İstanbul\",\"shippingCountry\": \"Türkiye\",\"shippingAddress\": \"İstanbul\"}}", ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            return View(response.Content);
        }

    }
}