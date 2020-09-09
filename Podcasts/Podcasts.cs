using System.Collections.Generic;

namespace PodscribeSearch.Podcasts
{
    public class Podcasts
    {
        public int resultCount { get; set; }
        public IEnumerable<Podcast> results { get; set; }
    }
    public class Podcast
    {
        public string artistName { get; set; }
    }
}
