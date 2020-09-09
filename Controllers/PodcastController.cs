using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PodscribeSearch.Podcasts;

namespace PodscribeSearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PodcastController : ControllerBase
    {
        private readonly IPodcastService _podcastSvc;

        private readonly ILogger<PodcastController> _logger;

        public PodcastController(ILogger<PodcastController> logger, IPodcastService podcastSvc)
        {
            _logger = logger;
            _podcastSvc = podcastSvc;
        }

        [HttpGet]
        public async Task<Podcasts.Podcasts> Get()
        {
            return await _podcastSvc.GetPodcast("Go Time");
        }
    }
}
