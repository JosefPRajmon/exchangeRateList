using Newtonsoft.Json;

namespace exchangeRateList.Models
{
    public class Currency
    {
        public int Id { get; set; }  // Primární klíč pro Entity Framework

        [JsonProperty( "amount" )]
        public decimal Amount { get; set; }

        [JsonProperty( "cnbMid" )]
        public decimal CnbMid { get; set; }

        [JsonProperty( "country" )]
        public string Country { get; set; }

        [JsonProperty( "currBuy" )]
        public decimal CurrBuy { get; set; }

        [JsonProperty( "currMid" )]
        public decimal CurrMid { get; set; }

        [JsonProperty( "currSell" )]
        public decimal CurrSell { get; set; }

        [JsonProperty( "ecbMid" )]
        public decimal EcbMid { get; set; }

        [JsonProperty( "move" )]
        public decimal Move { get; set; }

        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "shortName" )]
        public string ShortName { get; set; }

        [JsonProperty( "valBuy" )]
        public decimal ValBuy { get; set; }

        [JsonProperty( "valMid" )]
        public decimal ValMid { get; set; }

        [JsonProperty( "valSell" )]
        public decimal ValSell { get; set; }

        [JsonProperty( "validFrom" )]
        public DateTime ValidFrom { get; set; }

        [JsonProperty( "version" )]
        public int Version { get; set; }
    }
}
