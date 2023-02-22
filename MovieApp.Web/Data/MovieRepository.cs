using MovieApp.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Web.Data
{
    public class MovieRepository
    {
        private static readonly List<Movie> _movies = null;

        static MovieRepository()
        {
            _movies = new List<Movie>()
            {
                new Movie {MovieID=1,Title="film 1",Description="açıklama 1", Director="Yönetmen 1", Casts=new string[] {"oyuncu 1","oyuncu 2"}, ImageURL="1.jpg"},
                new Movie {MovieID=2,Title="film 2",Description="açıklama 2", Director="Yönetmen 2", Casts=new string[] {"oyuncu 1","oyuncu 2"},ImageURL="2.jpg"},
                new Movie {MovieID=3,Title="film 3",Description="açıklama 3", Director="Yönetmen 3", Casts=new string[] {"oyuncu 1","oyuncu 2"}, ImageURL = "3.jpg"},
                new Movie {MovieID=4,Title="film 4",Description="açıklama 4", Director="Yönetmen 4", Casts=new string[] {"oyuncu 1","oyuncu 2"}, ImageURL="1.jpg"},
                new Movie {MovieID=5,Title="film 5",Description="açıklama 5", Director="Yönetmen 5", Casts=new string[] {"oyuncu 1","oyuncu 2"},ImageURL="2.jpg"},
                new Movie {MovieID=6,Title="film 6",Description="açıklama 6", Director="Yönetmen 6", Casts=new string[] {"oyuncu 1","oyuncu 2"}, ImageURL = "3.jpg"}

            };
        }

        public static List<Movie> Movies
        {
            get { return _movies; }
        }

        public static void Add(Movie movie)
        {
            _movies.Add(movie);
        }

        public static Movie GetById(int id)
        {
            return _movies.FirstOrDefault(a => a.MovieID == id);
        }
    }
}
