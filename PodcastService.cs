
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace podscribe
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Use of HttpClient is guided by https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
    /// </remarks>
    public class PodcastService: IPodcastService
    {
        private readonly HttpClient _httpClient;

        public PodcastService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Podcast> GetPodcast()
        {
            //var uri = API.Catalog.GetAllCatalogItems(_remoteServiceBaseUrl,
            //                                         page, take, brand, type);
            var uri = "https://itunes.apple.com/lookup?id=1326503043";
            var responseString = await _httpClient.GetStringAsync(uri);

            var podcast = JsonConvert.DeserializeObject<Podcast>(responseString);
            return podcast;
        }
    }
}