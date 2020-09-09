using System.Threading.Tasks;

namespace PodscribeSearch.Podcasts
{
    public interface IPodcastService
    {
        Task<Podcasts> GetPodcast(string searchTerm);
    }

}