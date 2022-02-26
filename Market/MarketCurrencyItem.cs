using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoungPlatformAPILib.Market
{
    public class MarketCurrencyItem
    {
        [JsonProperty("name", Required =Required.Always)]        
        public string? Name { get; set; }

        [JsonProperty("symbol", Required = Required.Always)]
        public string? Symbol { get; set; }

        [JsonProperty("activeBuy", Required = Required.Always)]
        public bool ActiveBuy { get; set; }

        [JsonProperty("activeSell", Required = Required.Always)]
        public bool ActiveSell { get; set; }

        [JsonProperty("activeDeposit", Required = Required.Always)]
        public bool ActiveDeposit { get; set; }

        [JsonProperty("activeWithdraw", Required = Required.Always)]
        public bool ActiveWithdraw { get; set; }

        [JsonProperty("decimalPrecision", Required = Required.Always)]
        public int DecimalPrecision { get; set; }

        [JsonProperty("withdrawFee", Required = Required.Always)]
        public double WithdrawFee { get; set; }

        [JsonProperty("withdrawFeePercentage", Required = Required.Always)]
        public double WithdrawFeePercentage { get; set; }

        [JsonProperty("withdrawFixedFee", Required = Required.Always)]
        public bool WithdrawFixedFee { get; set; }
    }
}
