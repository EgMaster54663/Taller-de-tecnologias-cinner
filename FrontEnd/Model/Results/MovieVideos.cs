using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Model.Results
{
    public class MovieVideos
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("results")]
        public List<ResultMovieVideos> Results { get; set; }
    }
    public partial class ResultMovieVideos
    {
        [JsonProperty("iso_639_1")]
        public string Iso639_1 { get; set; }

        [JsonProperty("iso_3166_1")]
        public string Iso3166_1 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("site")]
        public string Site { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("official")]
        public bool Official { get; set; }

        [JsonProperty("published_at")]
        public DateTimeOffset PublishedAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
