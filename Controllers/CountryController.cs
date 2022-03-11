using ClassicWebAPI.Models;
using ClassicWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClassicWebAPI.Controllers
{
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult Welcome()
        {
            return Ok("Welcome to ClassicWebAPI.");
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return new JsonResult(await _countryService.GetAll());
        }

        /// <summary>
        /// api導向特定國家google map
        /// </summary>
        /// <param name="country">國家英文 不分大小寫</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Map(string country)
        {
            // https://localhost:44347/api/country/map?country=Hong%20Kong

            return this.Redirect(await _countryService.GetUrl(country));
        }


        /// <summary>
        /// 列出特定大陸上的國家
        /// </summary>
        /// <param name="subRegionReq">特定大陸名 不分大小寫</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetCountryBySubRegion([FromBody] SubRegionReq subRegionReq)
        {
            // https://localhost:44347/api/country/GetCountryBySubRegion?subRegion=Western Africa

            return new JsonResult(await _countryService.GetCountryBySubRegion(subRegionReq));
        }
    }
}