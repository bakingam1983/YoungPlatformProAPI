using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoungPlatformAPILib.Market
{
    public  class MarketItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("base")]
        public string? Base { get; set; }

        [JsonProperty("quote")]
        public string? Quote { get; set; }

        [JsonProperty("minTradeAmount")]
        public double MinTradeAmount { get; set; }

        [JsonProperty("makerFee")]
        public double MakerFee { get; set; }

        [JsonProperty("takerFee")]
        public double TakerFee { get; set; }

        [JsonProperty("baseDecimalPrecision")]
        public int BaseDecimalPrecision { get; set; }

        [JsonProperty("quoteDecimalPrecision")]
        public int QuoteDecimalPrecision { get; set; }

        [JsonProperty("minTickSize")]
        public double MinTickSize { get; set; }

        [JsonProperty("minOrderValue")]
        public double MinOrderValue { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("activeMarginTrading")]
        public bool ActiveMarginTrading { get; set; }
    }
}
