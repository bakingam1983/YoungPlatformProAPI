using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoungPlatformAPILib.History
{
    public class HistoryOrders
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("batch")]
        public int Batch { get; set; }

        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }

        [JsonProperty("data")]
        public List<HistoryOrder> Data { get; set; }
    }

    public class HistoryOrder
    {
        [JsonProperty("orderID")]
        public int OrderID { get; set; }

        [JsonProperty("cid")]
        public int Cid { get; set; }

        [JsonProperty("baseCurrency")]
        public string BaseCurrency { get; set; }

        [JsonProperty("quoteCurrency")]
        public string QuoteCurrency { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("brokerage")]
        public int Brokerage { get; set; }

        [JsonProperty("pendingVolume")]
        public double PendingVolume { get; set; }

        [JsonProperty("orderStatus")]
        public bool OrderStatus { get; set; }

        [JsonProperty("orderPlacementDate")]
        public DateTime OrderPlacementDate { get; set; }

        [JsonProperty("orderConfirmDate")]
        public DateTime OrderConfirmDate { get; set; }

        [JsonProperty("trades")]
        public List<HistoryTrade> Trades { get; set; }

        [JsonProperty("fee")]
        public string Fee { get; set; }
    }

    public class HistoryTrade
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
