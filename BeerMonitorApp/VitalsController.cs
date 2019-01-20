using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BeerMonitorApp
{
    public class VitalsController : Controller
    {
        [HttpGet]
        [Route("/vitals")]
        public async Task<JsonResult> JsonData()
        {
            var data = new List<BeerTempChartData>();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(@"https://beermonitorapi.azurewebsites.net/api/monitor/24");
            if (response.IsSuccessStatusCode)
            {
                data = JsonConvert.DeserializeObject<List<BeerTempChartData>>(await response.Content.ReadAsStringAsync());
            }
            data.ForEach(x => x.EntryTimestamp = x.EntryTimestamp.ToLocalTime());
            data = data.OrderBy(x => x.EntryTimestamp).ToList();
            return new JsonResult(data);
        }
    }
}
