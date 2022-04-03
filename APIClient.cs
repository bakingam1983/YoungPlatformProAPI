using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoungPlatformAPILib
{
    public class APIClient
    {
        public string APISecret { get; set; }
        public string APIPublicKey { get; set; }
        public string APIEndPoint { get; set; }
        public APIClient(string secret, string key, string endpoint)
        {
            APISecret = secret;
            APIPublicKey = key;
            if (endpoint.EndsWith("/"))
            {
                APIEndPoint = endpoint;
            }
            else { APIEndPoint = endpoint + "/"; }


        }

        internal string jsonToHMACBodyConverter(string requestJson)
        {
            string cleanedJson = requestJson.Replace("{", "");
            cleanedJson = cleanedJson.Replace("}", "");
            cleanedJson = cleanedJson.Replace("\"", "");
            cleanedJson = cleanedJson.Replace(":", "=");
            cleanedJson = cleanedJson.Replace("\r\n", "");
            cleanedJson = cleanedJson.Replace(" ", "");
            cleanedJson = cleanedJson.Replace(",", "&");

            //divido le chiavi e le riordino in ordine alfabetico
            var pezzi = cleanedJson.Split('&');
            List<string> Lista = new List<string>();

            for (int i = 0; i < pezzi.Length; i++)
            {
                Lista.Add(pezzi[i]);
            }

            Lista.Sort();

            string returnString = string.Empty;

            foreach (string str in Lista)
            {
                returnString += str + "&";
            }

            if (returnString.EndsWith("&"))
            {
                returnString = returnString.Remove(returnString.Length - 1, 1);
            }

            return returnString;
        }


        internal string ComputeHMAC(string body)
        {
            byte[] secret = System.Text.Encoding.UTF8.GetBytes(APISecret);
            byte[] bodyBuff = System.Text.Encoding.UTF8.GetBytes(body);

            using (System.Security.Cryptography.HMACSHA512 secure = new System.Security.Cryptography.HMACSHA512(secret))
            {
                var bodyHash = secure.ComputeHash(bodyBuff);

                var computedHMAC = BitConverter.ToString(bodyHash).Replace("-", "").ToUpper();
                return computedHMAC;
            }
        }

        public bool Ping()
        {
            RestClient client = new RestClient(APIEndPoint + "ping");

            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        internal string GetBodyRequestDefault(int timeout = 10)
        {
            DateTime data = DateTime.Now;
            var unixTime = ((DateTimeOffset)data).ToUnixTimeSeconds();

            string body = "{";
            body += $@"""timestamp"": {unixTime},";
            body += $@"""recvWindow"": {timeout}";
            body += "}";

            return body;
        }

        internal string GetBodyRequestPlaceOrder(string trade, string market, Orders.ESide side, Orders.EOrderType orderType, double volume, int timeout = 10)
        {
            DateTime data = DateTime.Now;
            var unixTime = ((DateTimeOffset)data).ToUnixTimeSeconds();

            string body = "{";
            body += $@"""timestamp"": {unixTime},";
            body += $@"""recvWindow"": {timeout},";
            body += $@"""trade"": {trade},";
            body += $@"""market"": {market},";
            body += $@"""side"": {side.ToString()},";
            body += $@"""type"": {orderType.ToString()},";
            body += $@"""volume"": {volume.ToString(System.Globalization.CultureInfo.InvariantCulture)}";
            body += "}";

            return body;
        }

        internal string GetBodyRequestCancelOrder(Orders.ESide side, string orderID, int timeout = 10)
        {
            DateTime data = DateTime.Now;
            var unixTime = ((DateTimeOffset)data).ToUnixTimeSeconds();

            string body = "{";
            body += $@"""timestamp"": {unixTime},";
            body += $@"""recvWindow"": {timeout},";
            body += $@"""side"": {side.ToString()},";
            body += $@"""orderId"": {orderID}";
            body += "}";

            return body;
        }

        internal string GetBodyRequestWithdrawRequest(string currency, double amount, string address, string gauthCode, string tag, int timeout = 10)
        {
            DateTime data = DateTime.Now;
            var unixTime = ((DateTimeOffset)data).ToUnixTimeSeconds();

            string body = "{";
            body += $@"""timestamp"": {unixTime},";
            body += $@"""recvWindow"": {timeout},";
            body += $@"""currency"": {currency},";
            body += $@"""amount"": {amount.ToString(System.Globalization.CultureInfo.InvariantCulture)},";
            body += $@"""address"": {address},";
            body += $@"""gauthCode"": {gauthCode},";
            body += $@"""tag"": {tag}";
            body += "}";

            return body;
        }


        public async Task<(Funding.DepositsWithdrawalsHeader, List<History.TradeItem>, List<WalletBalanceItem>)> GetAllHistory()
        {

            //trovo tutti i depositi e i prelievi
            Funding.DepositsWithdrawalsHeader depHistory = YoungPlatformAPILib.Funding.FundingEndpoint.GetAllDepositsWithrawals(this, 0, 1000);
            List<WalletBalanceItem> balance = Wallet.WalletEndpoint.GetWalletsBalances(this);

            List<string> Symbols = new List<string>();

            DateTime FirstDeposit = DateTime.Now;
            //Riempio una lista con tutte le currency
            foreach (var item in depHistory.Data)
            {
                if (!Symbols.Contains(item.Currency))
                {
                    Symbols.Add(item.Currency);
                }

                if (item.ConfirmDate.HasValue)
                {
                    if (item.ConfirmDate < FirstDeposit)
                    {
                        FirstDeposit = item.ConfirmDate.Value;
                    }
                }
            }

            foreach (var item in balance)
            {
                if (!Symbols.Contains(item.Symbol))
                {
                    Symbols.Add(item.Symbol);
                }
            }

            //prendiamo tutte le pair
            var markets = Market.MarketEndpoint.GetMarkets(this);

            //in base alle currency cerco se ci sono dei trade

            List<History.TradeItem> Trades=new List<History.TradeItem>();

            List<string> VerifiedPairs = new List<string>();
            foreach (var sym in Symbols)
            {
                //trovo tutte le pair con la currency
                var Pairs=markets.Where(x => x.Base == sym | x.Quote == sym).ToList();

                //per tute le pair vediamo se ci sono trade
                foreach (var pair in Pairs)
                {
                    if (!VerifiedPairs.Contains(pair.Name))
                    {
                        try
                        {
                            var trades = History.HistoryEndpoint.GetTradeHistoryByPair(this, pair.Name, ((DateTimeOffset)FirstDeposit).ToUnixTimeSeconds());
                            Trades.AddRange(trades.Data);

                            foreach (var trade in trades.Data)
                            {
                                if (!Symbols.Contains(trade.QuoteCurrency))
                                {
                                    Symbols.Add(trade.QuoteCurrency);
                                }
                                if (!Symbols.Contains(trade.BaseCurrency))
                                {
                                    Symbols.Add(trade.BaseCurrency);
                                }
                            }
                            
                            VerifiedPairs.Add(pair.Name);
                        }
                        catch (Exception ex)
                        {

                            throw;
                        }
                    }                    
                }                
            }


            return (depHistory, Trades, balance);
        }

        

    }
}
