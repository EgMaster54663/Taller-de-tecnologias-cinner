using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Model.Results
{
    public class PeopleImages
    {
        public int id { get; set; }
        public List<Profile> profiles { get; set; }
    }

    public class Profile
    {
        public double? aspect_ratio { get; set; }
        public int? height { get; set; }
        public object iso_639_1 { get; set; }
        public string file_path { get; set; }
        public double? vote_average { get; set; }
        public int? vote_count { get; set; }
        public int? width { get; set; }
    }
}
