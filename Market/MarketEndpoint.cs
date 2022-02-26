using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoungPlatformAPILib.Market
{
    public static class MarketEndpoint
    {
        public static List<MarketCurrencyItem> GetCurrencies(APIClient cli)
        {
            var client = new RestClient(cli.APIEndPoint + "currencies");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            if (!string.IsNullOrEmpty(response.Content))
            {
                var currencies=Newtonsoft.Json.JsonConvert.DeserializeObject<List<MarketCurrencyItem>>(response.Content);
                return currencies;
            }
            return null;
        }

        public static List<MarketCurrencyItem> GetMarkets(APIClient cli)
        {
            var client = new RestClient(cli.APIEndPoint + "markets");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            if (!string.IsNullOrEmpty(response.Content))
            {
                var currencies = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MarketCurrencyItem>>(response.Content);
                return currencies;
            }
            return null;
        }
    }
}
