using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace YoungPlatformAPILib.Market
{
    public static class MarketEndpoint
    {
        /// <summary>
        /// Returns Exchange currencies
        /// </summary>
        /// <param name="cli">APIClient</param>
        /// <returns>List<MarketCurrencyItem></returns>
        public static List<MarketCurrencyItem> GetCurrencies(APIClient cli)
        {
            var client = new RestClient(cli.APIEndPoint + "currencies");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<MarketCurrencyItem> currencies =JsonConvert.DeserializeObject<List<MarketCurrencyItem>>(response.Content);
                return currencies;
            }
            return null;
        }

        /// <summary>
        /// Returns active exchange Markets
        /// </summary>
        /// <param name="cli"></param>
        /// <returns></returns>
        public static List<MarketItem> GetMarkets(APIClient cli)
        {
            var client = new RestClient(cli.APIEndPoint + "markets");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<MarketItem> items = JsonConvert.DeserializeObject<List<MarketItem>>(response.Content);
                return items;
            }
            return null;
        }

        /// <summary>
        /// Returns ticker prices for given pair
        /// </summary>
        /// <param name="cli"></param>
        /// <param name="pair">BTC-EUR (Required) Request ticker for this pair</param>
        /// <returns></returns>
        public static MarketTicker GetTicketByPair(APIClient cli, string pair)
        {
            var client = new RestClient(cli.APIEndPoint + "ticker?pair=" + pair);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MarketTicker ticker = JsonConvert.DeserializeObject<MarketTicker>(response.Content);
                return ticker;
            }
            return null;
            
        }

        /// <summary>
        /// Returns latest trades for given pair
        /// </summary>
        /// <param name="cli"></param>
        /// <param name="pair">BTC-EUR (Required) Request trades for this pair</param>
        /// <returns></returns>
        public static List<MarketTrade> GetPublicTradesByPair(APIClient cli, string pair)
        {
            var client = new RestClient(cli.APIEndPoint + "trades?pair=" + pair);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<MarketTrade> trades = JsonConvert.DeserializeObject<List<MarketTrade>>(response.Content);
                return trades;
            }
            return null;

        }

        /// <summary>
        /// Returns current order book for given pair
        /// </summary>
        /// <param name="cli"></param>
        /// <param name="pair">BTC-EUR (Required) Request orderbook snapshot for this pair</param>
        /// <param name="depth">define orderbook depth to fetch. 25 <= depth <= 500</param>
        /// <returns></returns>
        public static MarketOrderBook GetOrderBookByPair(APIClient cli, string pair, int depth=25)
        {
            var client = new RestClient(cli.APIEndPoint + $"orderbook?pair={pair}&depth={depth}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MarketOrderBook trades = JsonConvert.DeserializeObject<MarketOrderBook>(response.Content);
                return trades;
            }
            return null;
        }

        /// <summary>
        /// Returns OHLCV charts for given pair according to request queries
        /// </summary>
        /// <param name="cli"></param>
        /// <param name="pair">BTC-EUR (Required) Request trades for this pair</param>
        /// <param name="interval">43200 define interval in minutues between candles</param>
        /// <param name="limit">100 define returned candles</param>
        /// <param name="timestamp">100 returned candles are before this timestamp. default now.</param>
        /// <returns></returns>
        public static List<MarketChartItem> GetChartsByPair(APIClient cli, string pair, int interval = 0, int limit=0, int timestamp=0)
        {
            var url = cli.APIEndPoint + $"charts?pair={pair}";
            if (interval > 0)
            {
                url += $"&interval={interval}";
            }

            if (limit > 0)
            {
                url += $"&limit={limit}";
            }

            if (timestamp > 0)
            {
                url += $"&timestamp={timestamp}";
            }

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                List<MarketChartItem> chartItems = JsonConvert.DeserializeObject<List<MarketChartItem>>(response.Content);
                return chartItems;
            }
            return null;
        }
    }
}
