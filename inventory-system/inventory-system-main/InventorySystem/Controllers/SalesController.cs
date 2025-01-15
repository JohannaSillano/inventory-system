using InventorySystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace InventorySystem.Controllers
{
    public class SalesController : Controller
    {
        private readonly ILogger<SalesController> _logger;
        private readonly HttpClient _httpClient;

        // Modify the constructor to accept the HttpClient and ILogger
        public SalesController(ILogger<SalesController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        // Action method to display sales data
        public async Task<IActionResult> SalesPage()
        {
            // Make an HTTP request to the POS API to get transaction details
            var response = await _httpClient.GetStringAsync("https://localhost:5001/api/SalesApi/GetTransactionDetailsWithProducts");
            var transactionDataResponse = JsonConvert.DeserializeObject<TransactionDataResponse>(response);

            // Pass the data to the view
            return View(transactionDataResponse);
        }
    }
}
