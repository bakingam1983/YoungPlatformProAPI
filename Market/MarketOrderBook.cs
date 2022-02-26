using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoungPlatformAPILib.Market
{
    public class MarketOrderBook
    {
        [JsonProperty("pair")]
        public string Pair { get; set; }

        [JsonProperty("bids")]
        public List<List<double>> Bids { get; set; }

        [JsonProperty("asks")]
        public List<List<double>> Asks { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }
        public DateTime DateTime
        {
            get
            {
                return DateTimeOffset.FromUnixTimeMilliseconds(Timestamp).DateTime;
            }
        }
    }
}
