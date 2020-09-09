using System.Threading.Tasks;

namespace podscribe
{
    public interface IPodcastService
    {
        Task<Podcast> GetPodcast();
    }

}