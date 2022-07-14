using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SweeftTaskApi.Respository
{
    public class CountryRespository : ICountryRespository
    {
        private static HttpClient client = new();
        public async void GenerateCountryDataFile()
        {
            var response =  await client.GetAsync("https://restcountries.com/v3.1/all");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var countries = JsonConvert.DeserializeObject<List<Country>>(json);

            foreach (var country in collection)
            {
                
            }
        }
    }
}
