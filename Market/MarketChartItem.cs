using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoungPlatformAPILib.Market
{
    public class MarketChartItem
    {
        [JsonProperty("open")]
        public double Open { get; set; }

        [JsonProperty("high")]
        public double High { get; set; }

        [JsonProperty("low")]
        public double Low { get; set; }

        [JsonProperty("close")]
        public double Close { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        public DateTime DateTime
        {
            get
            {
                return DateTimeOffset.FromUnixTimeMilliseconds(Time).DateTime;
            }
        }
    }
}
