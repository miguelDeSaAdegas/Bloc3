using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exo_semaine1.domaine
{
    [Serializable]
    public class Director : Person
    {


        private static readonly long serialVersionUID = 5952964360274024205L;
        private IList<Movie> directedMovies;

        public Director(String name, String firstname, DateTime birthDate) : base(name, firstname, birthDate)
        {
            directedMovies = new List<Movie>();
        }

        public Boolean AddMovie(Movie movie)
        {

            if (directedMovies.Contains(movie))
                return false;

            if (movie.Director == null)
                movie.Director = this;

            directedMovies.Add(movie);

            return true;
        }

        public IEnumerator<Movie> Movies()
        {
            return directedMovies.GetEnumerator();
        }
    }
}
