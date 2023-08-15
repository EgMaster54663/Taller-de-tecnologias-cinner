using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd.Model.Results
{
    public class Favorites
    {
        
        public List<object> movies = new List<object>();
        public void addfavorite(object Movie)
        {
            movies.Add(Movie);
        }
    }
}
