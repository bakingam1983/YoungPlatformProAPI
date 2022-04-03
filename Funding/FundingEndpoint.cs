using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoungPlatformAPILib.Funding
{
    public class FundingEndpoint
    {
        public static DepositsWithdrawalsHeader GetAllDepositsWithrawals(APIClient cli, int page, int batch)
        {
            string url = cli.APIEndPoint + $"transactions?page={page}&batch={batch}";

            string body = cli.GetBodyRequestDefault();
            var cleanbody = cli.jsonToHMACBodyConverter(body);
            var hmac = cli.ComputeHMAC(cleanbody);

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("apiKey", cli.APIPublicKey);
            request.AddHeader("hmac", hmac);

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                DepositsWithdrawalsHeader order = JsonConvert.DeserializeObject<DepositsWithdrawalsHeader>(response.Content);
                return order;
            }
            return null;
        }

        public static DepositsWithdrawalsHeader GetAllDepositsByCurrency(APIClient cli, string symbol)
        {
            string url = cli.APIEndPoint + $"deposits?currency={symbol}";

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("apiKey", cli.APIPublicKey);


            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                DepositsWithdrawalsHeader order = JsonConvert.DeserializeObject<DepositsWithdrawalsHeader>(response.Content);
                return order;
            }
            return null;
        }

        public static DepositsWithdrawalsHeader GetAllWithdrawalsByCurrency(APIClient cli, string symbol)
        {
            string url = cli.APIEndPoint + $"withdrawals?currency={symbol}";

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("apiKey", cli.APIPublicKey);


            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                DepositsWithdrawalsHeader order = JsonConvert.DeserializeObject<DepositsWithdrawalsHeader>(response.Content);
                return order;
            }
            return null;
        }

        public static WithdrawalRequestResponse SendWithdrawalRequest(APIClient cli, string currency, double amount, string address, string gauthCode, string tag)
        {
            string url = cli.APIEndPoint + $"withdraw";

            string body = cli.GetBodyRequestWithdrawRequest(currency, amount,address,gauthCode,tag,100000);
            var cleanbody = cli.jsonToHMACBodyConverter(body);
            var hmac = cli.ComputeHMAC(cleanbody);

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("apiKey", cli.APIPublicKey);
            request.AddHeader("hmac", hmac);


            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                WithdrawalRequestResponse order = JsonConvert.DeserializeObject<WithdrawalRequestResponse>(response.Content);
                return order;
            }
            return null;
        }

        public static DepositAddressResponse FetchDepositAddress(APIClient cli, string currency)
        {
            string url = cli.APIEndPoint + $"fetchDepositAddress?currency={currency}";

            string body = cli.GetBodyRequestDefault(30);
            var cleanbody = cli.jsonToHMACBodyConverter(body);
            var hmac = cli.ComputeHMAC(cleanbody);

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("apiKey", cli.APIPublicKey);
            request.AddHeader("hmac", hmac);


            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                DepositAddressResponse address = JsonConvert.DeserializeObject<DepositAddressResponse>(response.Content);
                return address;
            }
            return null;
        }

        public static DepositAddressResponse CreateDepositAddress(APIClient cli, string currency)
        {
            string url = cli.APIEndPoint + $"createDepositAddress?currency={currency}";

            string body = cli.GetBodyRequestDefault(30);
            var cleanbody = cli.jsonToHMACBodyConverter(body);
            var hmac = cli.ComputeHMAC(cleanbody);

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("apiKey", cli.APIPublicKey);
            request.AddHeader("hmac", hmac);


            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                DepositAddressResponse address = JsonConvert.DeserializeObject<DepositAddressResponse>(response.Content);
                return address;
            }
            return null;
        }
    }
}
