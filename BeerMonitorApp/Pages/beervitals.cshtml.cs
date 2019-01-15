using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace BeerMonitorApp.Pages
{
    public class beervitalsModel : PageModel
    {
        public string Temperature { get; set; }
        public string Humidity { get; set; }

        public async Task OnGet()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(@"https://beermonitorapi.azurewebsites.net/api/monitor/latest");
            if (response.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<BeerTempAndHumidity>(await response.Content.ReadAsStringAsync());
                Temperature = $"Temperature: {data.Temperature.ToString()} F";
                Humidity = $"Humidity: {data.Humidity} %";
            }
        }
    }
}