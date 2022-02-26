using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoungPlatformAPILib.Market
{
    public  class MarketTicker
    {
        [JsonProperty("pair")]
        public string Pair { get; set; }

        [JsonProperty("open")]
        public double Open { get; set; }

        [JsonProperty("high")]
        public double High { get; set; }

        [JsonProperty("low")]
        public double Low { get; set; }

        [JsonProperty("close")]
        public double Close { get; set; }

        [JsonProperty("bid")]
        public int Bid { get; set; }

        [JsonProperty("ask")]
        public double Ask { get; set; }

        [JsonProperty("percentChange")]
        public double PercentChange { get; set; }

        [JsonProperty("baseVolume")]
        public double BaseVolume { get; set; }

        [JsonProperty("quoteVolume")]
        public double QuoteVolume { get; set; }

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
