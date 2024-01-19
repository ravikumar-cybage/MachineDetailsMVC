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
            new Uri("https://172.17.0.3");
    }

    public async Task<IActionResult> Index()
    {
        var response = await _httpClient.GetAsync("https://localhost:7138/api/Machine");
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
