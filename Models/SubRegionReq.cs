using Newtonsoft.Json;
using System.Collections.Generic;

namespace ClassicWebAPI.Models
{
    public class SubRegionReq
    {
        [JsonProperty("subregion")]
        public string SubRegion { get; set; }

    }
}