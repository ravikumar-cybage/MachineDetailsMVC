using MachineDetailsMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class HomeController : Controller
{
    private readonly HttpClient _httpClient;

    public HomeController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress =
            new Uri("http://http://4.188.250.240:32000/api/");
 
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync("machine");
       if (response != null)
        {
            var resultString = await response.Content.ReadAsStringAsync();
            dynamic machineDetails = JsonConvert.DeserializeObject(resultString);
            ViewBag.MachineName = machineDetails.machineName;
            ViewBag.MachineIP = machineDetails.machineIP;
            ViewBag.MachineOS = machineDetails.machineOS;
            ViewBag.Timestamp = machineDetails.timestamp;
        }

        return View();
    }
}
