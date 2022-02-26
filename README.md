# YoungPlatformProAPI

Non official wrapper for Young Platform Pro API

## Example

```C#
YoungPlatformAPILib.APIClient cli = new YoungPlatformAPILib.APIClient("YOUR-SECRET-KEY", "YOUR-PUBLIC-KEY", "https://api.youngplatform.com/api/v3/");

var pong = cli.Ping();

var balance= YoungPlatformAPILib.Wallet.WalletEndpoint.GetWalletsBalances(cli);
var Currencies = YoungPlatformAPILib.Market.MarketEndpoint.GetCurrencies(cli);
```
