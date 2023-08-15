using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Model.Results
{
    public class MovieImages
    {
        public List<Backdrop> backdrops { get; set; }
        public int id { get; set; }
        public List<Logo> logos { get; set; }
        public List<Poster> posters { get; set; }
    }

    public class Poster
    {
        public double aspect_ratio { get; set; }
        public double height { get; set; }
        public string iso_639_1 { get; set; }
        public string file_path { get; set; }
        public double vote_average { get; set; }
        public double vote_count { get; set; }
        public double width { get; set; }
    }

    public class Logo
    {
        public double aspect_ratio { get; set; }
        public double height { get; set; }
        public string iso_639_1 { get; set; }
        public string file_path { get; set; }
        public double vote_average { get; set; }
        public double vote_count { get; set; }
        public double width { get; set; }
    }

    public class Backdrop
    {
        public double aspect_ratio { get; set; }
        public double height { get; set; }
        public string iso_639_1 { get; set; }
        public string file_path { get; set; }
        public double vote_average { get; set; }
        public double vote_count { get; set; }
        public double width { get; set; }
    }
}
