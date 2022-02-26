using RestSharp;
using System;
using System.Collections.Generic;
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
            else { APIEndPoint = endpoint +"/"; }
            
            
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
            var pezzi = cleanedJson.Split("&");
            List<string> Lista = new List<string>();

            for(int i = 0; i < pezzi.Length; i++)
            {
                Lista.Add(pezzi[i]);
            }

            Lista.Sort();

            string returnString=string.Empty;

            foreach(string str in Lista)
            {
                returnString += str + "&";
            }

            if (returnString.EndsWith("&"))
            {
                returnString=returnString.Remove(returnString.Length - 1,1);
            }

            return returnString;
        }


        internal string ComputeHMAC(string body)
        {
            byte[] secret = System.Text.Encoding.UTF8.GetBytes(APISecret);
            byte[] bodyBuff= System.Text.Encoding.UTF8.GetBytes(body);

            using (System.Security.Cryptography.HMACSHA512 secure = new System.Security.Cryptography.HMACSHA512(secret))
            {
                var bodyHash = secure.ComputeHash(bodyBuff);

                var computedHMAC=BitConverter.ToString(bodyHash).Replace("-", "").ToUpper();
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

        internal string GetBodyRequest(int timeout=10)
        {
            DateTime data = DateTime.Now;
            var unixTime = ((DateTimeOffset)data).ToUnixTimeSeconds();

            string body = "{";
            body += @$"""timestamp"": {unixTime},";
            body += @$"""recvWindow"": {timeout}";
            body += "}";

            return body;
        }

            
     
    }
}
