using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YoungPlatformAPILib.Wallet
{

    public static class WalletEndpoint
    {
        public static List<WalletBalanceItem> GetWalletsBalances(APIClient cli)
        {
            string body=cli.GetBodyRequest();
            var cleanbody = cli.jsonToHMACBodyConverter(body);
            var hmac = cli.ComputeHMAC(cleanbody);
          
            var client = new RestClient(cli.APIEndPoint + "balances");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("apiKey", cli.APIPublicKey);
            request.AddHeader("hmac", hmac);

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            List<WalletBalanceItem> resp = new List<WalletBalanceItem>();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                resp = JsonConvert.DeserializeObject<List<WalletBalanceItem>>(response.Content);
            }

            if (!(resp == null))
            {
                return resp;
            }
            return null;

        }
    }
}
