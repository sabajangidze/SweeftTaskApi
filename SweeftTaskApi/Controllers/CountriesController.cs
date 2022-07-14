using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SweeftTaskApi.Respository;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SweeftTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRespository _countryRespository;

        public CountriesController(ICountryRespository countryRespository)
        {
            _countryRespository = countryRespository;
        }

        [HttpGet(nameof(GetCountries))]
        public IActionResult GetCountries()
        {
            _countryRespository.GenerateCountryDataFile();
            return Ok();
        }

        //[HttpGet(nameof(GetCountry))]
        //public async Task<IActionResult> GetCountry(string name)
        //{
        //    var response = await client.GetAsync($"https://restcountries.com/v3.1/name/{name}");
        //    response.EnsureSuccessStatusCode();

        //    var json = await response.Content.ReadAsStringAsync();

        //    var country = JsonConvert.DeserializeObject<List<Country>>(json);

        //    return Ok(country);
        //}
    }
}
