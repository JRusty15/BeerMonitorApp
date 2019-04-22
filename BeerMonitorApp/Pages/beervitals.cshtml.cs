using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace BeerMonitorApp.Pages
{
    public class beervitalsModel : PageModel
    {
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public string EntryTimestamp { get; set; }

        public async Task OnGet()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(@"https://beermonitorapi.azurewebsites.net/api/monitor/latest");
            if (response.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<BeerTempChartData>(await response.Content.ReadAsStringAsync());
                Temperature = $"Temperature: {Math.Round(data.Temperature, 2)} F";
                Humidity = $"Humidity: {Math.Round(data.Humidity, 2)} %";
                EntryTimestamp = $"Timestamp: {data.EntryTimestamp.ToLocalTime().ToString("MM/dd/yyyy hh:mm tt")}";
            }
        }
    }
}