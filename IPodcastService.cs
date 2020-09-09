using System.Threading.Tasks;

namespace podscribe
{
    public interface IPodcastService
    {
        Task<Podcasts> GetPodcast(string searchTerm);
    }

}