using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoungPlatformAPILib.Orders
{
    public class OrderItem
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
        public int Rate { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("brokerage")]
        public int Brokerage { get; set; }

        [JsonProperty("pendingVolume")]
        public double PendingVolume { get; set; }

        [JsonProperty("orderStatus")]
        public bool OrderStatus { get; set; }

        [JsonProperty("orderPlacementDate")]
        public DateTime OrderPlacementDate { get; set; }

        [JsonProperty("orderConfirmDate")]
        public DateTime? OrderConfirmDate { get; set; }

        [JsonProperty("trades")]
        public List<History.TradeItem> Trades { get; set; }

        [JsonProperty("fee")]
        public string Fee { get; set; }
    }
}
