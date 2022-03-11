using ClassicWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassicWebAPI.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryInfo>> GetAll();
        Task<string> GetUrl(string countryName);
        Task<SubRegionInfo> GetCountryBySubRegion(SubRegionReq subRegionReq);
    }
}