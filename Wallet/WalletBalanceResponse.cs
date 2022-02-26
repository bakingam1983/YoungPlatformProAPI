using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace YoungPlatformAPILib
{
    
    public class WalletBalanceResponse
    {
        public List<WalletBalanceResponseItem> Items { get; set; }

        public WalletBalanceResponse()
        {
            Items = new List<WalletBalanceResponseItem>();
        }
    }

    public class WalletBalanceResponseItem
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("balanceInTrade")]
        public double BalanceInTrade { get; set; }

        public WalletBalanceResponseItem()
        {

        }
    }
}
