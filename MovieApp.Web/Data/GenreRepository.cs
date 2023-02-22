using MovieApp.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Web.Data
{
    public class GenreRepository
    {
        private static readonly List<Genre> _genres = null;

        static GenreRepository()
        {
            _genres = new List<Genre>()
            {
                new Genre {GenreID=1,GenreName="Macera"},
                new Genre {GenreID=2,GenreName="Komedi"},
                new Genre {GenreID=3,GenreName="Romantik"},
                new Genre {GenreID=4,GenreName="Savaş"},
            };
        }

        public static List<Genre> Genres
        {
            get { return _genres; }
        }

        public static void Add(Genre genre)
        {
            _genres.Add(genre);
        }

        public static Genre GetById(int id)
        {
            return _genres.FirstOrDefault(a => a.GenreID == id);
        }
    }
}
