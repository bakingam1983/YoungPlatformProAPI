using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace YoungPlatformAPILib.History
{
    public static class HistoryEndpoint
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cli"></param>
        /// <param name="pair">BTC-EUR (Required) The pair to fetch orders for</param>
        /// <param name="since">1627917598000 Starting timestamp in milliseconds</param>
        /// <param name="until">1627917598000 Ending timestamp in milliseconds</param>
        /// <param name="limit">100 Defines the maximum number of returned trades up to 100</param>
        /// <returns></returns>
        public static TradeHistory? GetTradeHistoryByPair(APIClient cli, string pair, long since=0, long until=0, int limit=100)
        {
            string url = cli.APIEndPoint + $"tradeHistory?pair={pair}";

            if(since> 0)
            {
                url += $"&since={since}";
            }
            if (until > 0)
            {
                url += $"&until={until}";
            }
            if (limit > 0)
            {
                url += $"&limit={limit}";
            }

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
                TradeHistory history = JsonConvert.DeserializeObject<TradeHistory>(response.Content);
                return history;
            }
            return null;
        }

        /// <summary>
        /// Returns your order history for given pair
        /// </summary>
        /// <param name="cli"></param>
        /// <param name="pair">BTC-EUR (Required) The pair to fetch orders for</param>
        /// <param name="since">1627917598000 Starting timestamp in milliseconds</param>
        /// <param name="until">1627917598000 Ending timestamp in milliseconds</param>
        /// <param name="limit">100 Defines the maximum number of returned orders up to 100</param>
        /// <returns></returns>
        public static HistoryOrder? GetOrderHistoryByPair(APIClient cli, string pair, long since = 0, long until = 0, int limit = 100)
        {
            string url = cli.APIEndPoint + $"orderHistory?pair={pair}";

            if (since > 0)
            {
                url += $"&since={since}";
            }
            if (until > 0)
            {
                url += $"&until={until}";
            }
            if (limit > 0)
            {
                url += $"&limit={limit}";
            }

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
                HistoryOrder history = JsonConvert.DeserializeObject<HistoryOrder>(response.Content);
                return history;
            }
            return null;
        }

        /// <summary>
        /// Returns your buy order history for given pair
        /// </summary>
        /// <param name="cli"></param>
        /// <param name="pair">BTC-EUR (Required) The pair to fetch orders for</param>
        /// <param name="since">1627917598000 Starting timestamp in milliseconds</param>
        /// <param name="until">1627917598000 Ending timestamp in milliseconds</param>
        /// <param name="limit">100 Defines the maximum number of returned orders up to 100</param>
        /// <returns></returns>
        public static HistoryOrder? GetBuyOrderHistoryByPair(APIClient cli, string pair, long since = 0, long until = 0, int limit = 100)
        {
            string url = cli.APIEndPoint + $"buyOrderHistory?pair={pair}";

            if (since > 0)
            {
                url += $"&since={since}";
            }
            if (until > 0)
            {
                url += $"&until={until}";
            }
            if (limit > 0)
            {
                url += $"&limit={limit}";
            }

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
                HistoryOrder history = JsonConvert.DeserializeObject<HistoryOrder>(response.Content);
                return history;
            }
            return null;
        }

        /// <summary>
        /// Returns your sell order history for given pair
        /// </summary>
        /// <param name="cli"></param>
        /// <param name="pair">BTC-EUR (Required) The pair to fetch orders for</param>
        /// <param name="since">1627917598000 Starting timestamp in milliseconds</param>
        /// <param name="until">1627917598000 Ending timestamp in milliseconds</param>
        /// <param name="limit">100 Defines the maximum number of returned orders up to 100</param>
        /// <returns></returns>
        public static HistoryOrder? GetSellOrderHistoryByPair(APIClient cli, string pair, long since = 0, long until = 0, int limit = 100)
        {
            string url = cli.APIEndPoint + $"sellOrderHistory?pair={pair}";

            if (since > 0)
            {
                url += $"&since={since}";
            }
            if (until > 0)
            {
                url += $"&until={until}";
            }
            if (limit > 0)
            {
                url += $"&limit={limit}";
            }

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
                HistoryOrder history = JsonConvert.DeserializeObject<HistoryOrder>(response.Content);
                return history;
            }
            return null;
        }

        /// <summary>
        /// Returns an order by Id
        /// </summary>
        /// <param name="cli"></param>
        /// <param name="orderId">518318179 (Required) The ID of the desired order</param>
        /// <returns></returns>
        public static HistoryOrder? GetOrderById(APIClient cli, long orderId)
        {
            string url = cli.APIEndPoint + $"orderbyid?orderId={orderId}";

            
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
                HistoryOrder history = JsonConvert.DeserializeObject<HistoryOrder>(response.Content);
                return history;
            }
            return null;
        }

    }
}
