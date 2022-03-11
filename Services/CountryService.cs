using ClassicWebAPI.Models;
using ClassicWebAPI.Services.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ClassicWebAPI.Services
{
    public class CountryService : ICountryService
    {
        private readonly IHttpClientService _httpClientService;

        public CountryService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IEnumerable<CountryInfo>> GetAll()
        {
            var httpResponseMessage = await _httpClientService.GetAsync("https://restcountries.com/v3.1/all");
            if (!httpResponseMessage.IsSuccessStatusCode) return null;
            var data = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<CountryInfo>>(data);
        }
        public async Task<string> GetUrl(string countryName)
        {
            IEnumerable<CountryInfo> countrys = await GetAll();
            //return "https://goo.gl/maps/1sEnNmT47ffrC8MU8";
            return countrys.First(f => f.CountryName.Common.ToUpper().Contains(countryName.ToUpper())).Map.GoogleMap; 
             
        }



        public async Task<SubRegionInfo> GetCountryBySubRegion(SubRegionReq subRegionReq) {

            IEnumerable<CountryInfo> countrys = await GetAll();
            SubRegionInfo subRegionInfo = new SubRegionInfo(subRegionReq.SubRegion);
            subRegionInfo.Countrys = countrys.Where(w=> w.SubRegion!=null && w.SubRegion.Contains(subRegionReq.SubRegion)).Select(p => p.CountryName.Common)
                .Distinct().ToList();
            return subRegionInfo;
        }
    }
}