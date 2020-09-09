
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace PodscribeSearch.Podcasts
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Use of HttpClient is guided by:
    ///  - https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
    ///  - https://josef.codes/you-are-probably-still-using-httpclient-wrong-and-it-is-destabilizing-your-software/
    /// </remarks>
    public class PodcastService : IPodcastService
    {
        private readonly HttpClient _httpClient;

        public PodcastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Podcasts> GetPodcast(string searchTerm)
        {
            UriBuilder builder = new UriBuilder("https://itunes.apple.com/search");
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["entity"] = "podcast";
            query["term"] = searchTerm;
            builder.Query = query.ToString();
            var responseString = await _httpClient.GetStringAsync(builder.ToString());
            var podcasts = JsonSerializer.Deserialize<Podcasts>(responseString);
            return podcasts;
        }
    }
}