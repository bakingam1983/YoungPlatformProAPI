using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoungPlatformAPILib.Orders
{
    public enum ESide
    {
        ND=0,
        BUY=1,
        SELL=2
    }
    public enum EOrderType
    {
        ND=0,
        MARKET = 1,
        LIMIT = 2
    }
    public static class OrdersEndpoint
    {
        /// <summary>
        /// Get open orders for a certain pair
        /// </summary>
        /// <param name="cli"></param>
        /// <param name="pair">BTC-EUR (Required) The pair to fetch orders for</param>
        /// <returns></returns>
        public static List<OrderItem> GetOpenOrdersByPair(APIClient cli, string pair)
        {
            string url = cli.APIEndPoint + $"openorders?pair={pair}";


            string body = cli.GetBodyRequestDefault();
            var cleanbody = cli.jsonToHMACBodyConverter(body);
            var hmac = cli.ComputeHMAC(cleanbody);

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("apiKey", cli.APIPublicKey);
            request.AddHeader("hmac", hmac);

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<OrderItem> history = JsonConvert.DeserializeObject<List<OrderItem>>(response.Content);
                return history;
            }
            return null;
        }

        /// <summary>
        /// Places an order on Exchange
        /// {
        ///"trade": "BTC",
        ///"market": "EUR",
        ///"side": "BUY",
        ///"type": "MARKET",
        ///"volume": 50
        ///}
        /// </summary>
        /// <param name="cli"></param>
        /// <param name="trade">symbol to trade ex: BTC</param>
        /// <param name="market">market to trade with ex: EUR</param>
        /// <param name="side">BUY or SELL</param>
        /// <param name="volume">VOLUME</param>
        /// <returns></returns>
        public static OrderItem PlaceOrderMarketOrder(APIClient cli, string trade, string market, ESide side,  double volume)
        {
            string url = cli.APIEndPoint + $"placeOrder";


            string body = cli.GetBodyRequestPlaceOrder(trade, market, side, EOrderType.LIMIT, volume, 100000);
            var cleanbody = cli.jsonToHMACBodyConverter(body);
            var hmac = cli.ComputeHMAC(cleanbody);

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("apiKey", cli.APIPublicKey);
            request.AddHeader("hmac", hmac);

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                OrderItem order = JsonConvert.DeserializeObject<OrderItem>(response.Content);
                return order;
            }
            return null;
        }

        /// <summary>
        /// Places an order on Exchange
        /// {
        ///"trade": "BTC",
        ///"market": "EUR",
        ///"side": "BUY",
        ///"type": "MARKET",
        ///"volume": 50
        ///}
        /// </summary>
        /// <param name="cli"></param>
        /// <param name="trade">symbol to trade ex: BTC</param>
        /// <param name="market">market to trade with ex: EUR</param>
        /// <param name="side">BUY or SELL</param>
        /// <param name="volume">VOLUME</param>
        /// <returns></returns>
        public static OrderItem PlaceOrderLimitOrder(APIClient cli, string trade, string market, ESide side, double volume)
        {
            string url = cli.APIEndPoint + $"placeOrder";


            string body = cli.GetBodyRequestPlaceOrder(trade, market, side, EOrderType.LIMIT, volume,100000);
            var cleanbody = cli.jsonToHMACBodyConverter(body);
            var hmac = cli.ComputeHMAC(cleanbody);

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("apiKey", cli.APIPublicKey);
            request.AddHeader("hmac", hmac);

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                OrderItem order = JsonConvert.DeserializeObject<OrderItem>(response.Content);
                return order;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cli"></param>
        /// <param name="side"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static OrderItem CancelOrder(APIClient cli, ESide side, string orderId)
        {
            string url = cli.APIEndPoint + $"cancelOrder";


            string body = cli.GetBodyRequestCancelOrder(side, orderId, 100000);
            var cleanbody = cli.jsonToHMACBodyConverter(body);
            var hmac = cli.ComputeHMAC(cleanbody);

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("apiKey", cli.APIPublicKey);
            request.AddHeader("hmac", hmac);

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                OrderItem order = JsonConvert.DeserializeObject<OrderItem>(response.Content);
                return order;
            }
            return null;
        }
    }
}
