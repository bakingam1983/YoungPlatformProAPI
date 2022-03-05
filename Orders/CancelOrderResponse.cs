using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoungPlatformAPILib.Orders
{
    internal class CancelOrderResponse
    {
        [JsonProperty("ooc")]
        public int ooc { get; set; }
    }
}
