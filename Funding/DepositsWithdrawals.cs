using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoungPlatformAPILib.Funding
{
    public class DepositAddressResponse
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }
    }
    public class WithdrawalRequestResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
    public class DepositsWithdrawalsItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("rejectReason")]
        public object RejectReason { get; set; }

        [JsonProperty("fee")]
        public double Fee { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("explorerUrl")]
        public string ExplorerUrl { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonProperty("requestDate")]
        public DateTime RequestDate { get; set; }

        [JsonProperty("confirmDate")]
        public DateTime? ConfirmDate { get; set; }

        [JsonProperty("currentTxnCount")]
        public int CurrentTxnCount { get; set; }

        [JsonProperty("requiredTxnCount")]
        public int RequiredTxnCount { get; set; }

        [JsonProperty("additionalData")]
        public AdditionalData? AdditionalData { get; set; }
    }

    public class DepositsWithdrawalsHeader
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("batch")]
        public int Batch { get; set; }

        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }

        [JsonProperty("data")]
        public List<DepositsWithdrawalsItem> Data { get; set; }
    }

    public class AdditionalData
    {
        [JsonProperty("name")]
        public string Name {get;set;}
    }
}
