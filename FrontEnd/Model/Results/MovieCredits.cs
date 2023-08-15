using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Model.Results
{
    public class MovieCredits
    {
        public List<Cast> cast { get; set; }
        public List<Crew> crew { get; set; }
        public int id { get; set; }
    }
    public class Crew
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public List<int> genre_ids { get; set; }
        public long id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public string credit_id { get; set; }
        public string department { get; set; }
        public string job { get; set; }
    }

    public class Cast
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public List<int> genre_ids { get; set; }
        public long id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public string poster_path { get; set; }
        public string release_date { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public string character { get; set; }
        public string credit_id { get; set; }
        public int order { get; set; }
    }
}
