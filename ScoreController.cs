using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace ScoreCards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        [HttpGet("GetHomeMatches")]
        public async Task<IActionResult>Home()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://www.cricbuzz.com/api/home");
            if(response.IsSuccessStatusCode)
            {
                var Home = await response.Content.ReadAsStringAsync();
                return Ok(Home);
             }
             else
             {
                return StatusCode((int)response.StatusCode, "Error fetching score");
            }
        }
        [HttpGet("")]
        public async Task<IActionResult>GetScore()
        {
            var clint = new HttpClient();

            var Get = await clint.GetAsync("https://www.cricbuzz.com/api/mcenter/livescore/151829");
            var Score = await Get.Content.ReadAsStreamAsync();

           

            return Ok(Score);
        }
    }
}
