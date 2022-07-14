using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using System.Text;

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
            //I didnt find country's prop name
            int index = 0;
            // index is temporary
            foreach (var country in countries)
            {
                FileStream file = new FileStream(@$"D:\Test\{country.SubRegion}{index}.txt", FileMode.Create); //We need country's name but I dont know prop's name
                StreamWriter writer = new StreamWriter(file, Encoding.Unicode);
                writer.WriteLine("Region: " + country.Region);
                writer.WriteLine("Subegion: " + country.SubRegion);
                writer.WriteLine("Lating: " + country.Lating);
                writer.WriteLine("Area: " + country.Area);
                writer.WriteLine("Popilation: " + country.Population);
                writer.Close();
                index++;
            }
        }
    }
}
