using Newtonsoft.Json;
using System.Collections.Generic;

namespace ClassicWebAPI.Models
{
    public class SubRegionInfo
    {
        public SubRegionInfo() { 
        
        }
        public SubRegionInfo(string subRegion)
        {
            this.SubRegion = subRegion;
        }
        [JsonProperty("subregion")]
        public string SubRegion { get; set; }

        [JsonProperty("countrys")]
        public List<string> Countrys { get; set; }
    }
}