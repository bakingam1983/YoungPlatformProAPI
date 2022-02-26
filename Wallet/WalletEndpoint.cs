using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YoungPlatformAPILib.Wallet
{

    public static class WalletEndpoint
    {
        public static List<WalletBalanceResponseItem> GetWalletsBalances(APIClient cli)
        {
            DateTime data = DateTime.Now;
            var unixTime = ((DateTimeOffset)data).ToUnixTimeSeconds();
            //Console.WriteLine(unixTime);
            string body = "{";
            body += @$"""timestamp"": {unixTime},";
            body += @$"""recvWindow"": 10";
            body += "}";
            var cleanbody = cli.jsonToHMACBodyConverter(body);
            //Console.WriteLine(cleanbody);
            var hmac = cli.ComputeHMAC(cleanbody);
            //Console.WriteLine(hmac);

            var client = new RestClient(cli.APIEndPoint + "balances");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("apiKey", cli.APIPublicKey);
            request.AddHeader("hmac", hmac);

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            List<WalletBalanceResponseItem> resp = new List<WalletBalanceResponseItem>();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                resp = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WalletBalanceResponseItem>>(response.Content);
            }

            if (!(resp == null))
            {
                return resp;
            }
            return null;

        }
    }
}
