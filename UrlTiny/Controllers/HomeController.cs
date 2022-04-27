using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Interfaces;
using UrlTiny.Models;

namespace UrlTiny.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IUrlTinyService _urlTinyService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IUrlTinyService urlTinyService, ILogger<HomeController> logger)
        {
            _urlTinyService = urlTinyService;
            _logger = logger;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            return Ok("UrlTiny API");
        }

        [HttpGet("urltiny/{shorturl}", Name = "Get")]
        public async Task<IActionResult> Get(string shorturl, [FromQuery(Name = "redirect")] bool redirect = true)
        {
            var shortUrl = await _urlTinyService.GetShortUrlByShortCode(shorturl);

            if (shortUrl != null)
            {
                if(redirect)
                {
                    return Redirect(shortUrl.Data.LongUrl);
                }
                else
                {
                    return Ok(shortUrl);
                }
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var shortUrls = await _urlTinyService.GetAll();
            return Ok(shortUrls);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShortUrlRequestModel urlTiny)
        {
            if (urlTiny == null)
            {
                return BadRequest();
            }

            var shortUrl = await _urlTinyService.CreateShortUrl(urlTiny.LongUrl);

            if (shortUrl != null)
            {
                return CreatedAtRoute("Get", new { shorturl = shortUrl.Data.ShortUrl }, shortUrl);
            }

            return BadRequest();
        }
    }
}