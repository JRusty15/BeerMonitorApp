using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            var response = await client.GetAsync(@"https://beermonitorapi.azurewebsites.net/api/monitor");
            if (response.IsSuccessStatusCode)
            {
                data = JsonConvert.DeserializeObject<List<BeerTempChartData>>(await response.Content.ReadAsStringAsync());
            }
            return new JsonResult(data);
        }
    }
}
