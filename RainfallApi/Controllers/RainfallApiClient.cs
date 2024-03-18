
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;


namespace RainfallApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RainfallApiClient : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public RainfallApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://environment.data.gov.uk");
        }


        [HttpGet("/flood-monitoring/id/stations/{stationId}")]
        public async Task<IActionResult> GetStationInfo(int stationId)
        {
            try
            {

                HttpResponseMessage response = await _httpClient.GetAsync($"/flood-monitoring/id/stations/{stationId}");


                if (response.IsSuccessStatusCode)
                {

                    string responseBody = await response.Content.ReadAsStringAsync();
                    return Ok(responseBody);
                }
                else
                {

                    return StatusCode((int)response.StatusCode, $"Request failed with status code: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request error
                return StatusCode(500, $"HTTP request error: {ex.Message}");
            }
        }
    }
}
