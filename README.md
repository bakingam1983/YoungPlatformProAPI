# YoungPlatformProAPI

Non official wrapper for Young Platform Pro API

<h2>Usage</h2>
<code>
YoungPlatformAPILib.APIClient cli = new YoungPlatformAPILib.APIClient("YOUR-SECRET-KEY", "YOUR-PUBLIC-KEY", "https://api.youngplatform.com/api/v3/");

var pong = cli.Ping();

var balance= YoungPlatformAPILib.Wallet.WalletEndpoint.GetWalletsBalances(cli);
var Currencies = YoungPlatformAPILib.Market.MarketEndpoint.GetCurrencies(cli);
</code>