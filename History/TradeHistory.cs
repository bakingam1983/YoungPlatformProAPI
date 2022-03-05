using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoungPlatformAPILib.History
{
    public class TradeHistory
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("batch")]
        public int Batch { get; set; }

        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }

        [JsonProperty("data")]
        public List<TradeItem> Data { get; set; }
    }

    public class TradeItem
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("orderID")]
        public int OrderID { get; set; }

        [JsonProperty("baseCurrency")]
        public string BaseCurrency { get; set; }

        [JsonProperty("quoteCurrency")]
        public string QuoteCurrency { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("taker")]
        public bool Taker { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }

        [JsonProperty("executionDate")]
        public DateTime ExecutionDate { get; set; }
    }
}
