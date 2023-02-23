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
                    new Movie {
                    MovieID=1,
                    Title="Jiu Jitsu",
                    Description="Every six years, an ancient order of jiu-jitsu fighters joins forces to battle a vicious race of alien invaders. But when a celebrated war hero goes down in defeat, the fate of the planet and mankind hangs in the balance.",
                    Director="Dimitri Logothetis",
                    Casts=new string[] { "Nicolas Cage", "Alain Moussi"},
                    ImageURL="1.jpg",
                    GenreID=1
                },
                new Movie {
                    MovieID=2,
                    Title="Fatman",
                    Description="A rowdy, unorthodox Santa Claus is fighting to save his declining business. Meanwhile, Billy, a neglected and precocious 12 year old, hires a hit m...",
                    Director="Eshom Nelms",
                    Casts=new string[] { "Mel Gibson", "Walton Goggins","Michelle Lan"},
                    ImageURL="2.jpg",
                    GenreID=1
                },
                new Movie {
                    MovieID=3,
                    Title="The Dalton Gang",
                    Description="When their brother Frank is killed by an outlaw, brothers Bob Dalton, Emmett Dalton and Gray Dalton join their local sheriff's department. When the...",
                    Director="Christopher Forbes",
                    Casts=new string[] { "oyuncu 1","oyuncu 2"},
                    ImageURL="3.jpg",
                    GenreID=3
                },
                    new Movie {
                    MovieID=4,
                    Title="Tenet",
                    Description="Armed with only one word - Tenet - and fighting for the survival of the entire world, the Protagonist journeys through a twilight world of internat...",
                    Director="Christopher Nolan",
                    Casts=new string[] { "Robert Pattinson", "Elizabeth Debicki"},
                    ImageURL="4.jpg",
                    GenreID=3
                },
                new Movie {
                    MovieID=5,
                    Title="The Craft: Legacy",
                    Description="An eclectic foursome of aspiring teenage witches get more than they bargained for as they lean into their newfound powers.",
                    Director="Zoe Lister-Jones",
                    Casts=new string[] { "Cailee Spaeny", "Zoey Luna"},
                    ImageURL="5.jpg",
                    GenreID=3
                },
                new Movie {
                    MovieID=6,
                    Title="Hard Kill",
                    Description="The work of billionaire tech CEO Donovan Chalmers is so valuable that he hires mercenaries to protect it, and a terrorist group kidnaps his daughte...",
                    Director="Matt Eskandari",
                    Casts=new string[] { "Bruce Willis", "Jesse Metcalfe"},
                    ImageURL="6.jpg",
                    GenreID=4
                }
            };
        }

        public static List<Movie> Movies
        {
            get { return _movies; }
        }

        public static void Add(Movie movie)
        {
            movie.MovieID = _movies.Count() + 1;
            _movies.Add(movie);
        }

        public static Movie GetById(int id)
        {
            return _movies.FirstOrDefault(a => a.MovieID == id);
        }

        public static void Edit(Movie duzenle)
        {
            foreach (var movie in _movies)
            {
                if (movie.MovieID == duzenle.MovieID)
                {
                    movie.Title = duzenle.Title;
                    movie.Description = duzenle.Description;
                    movie.Director = duzenle.Director;
                    movie.ImageURL = duzenle.ImageURL;
                    movie.GenreID = duzenle.GenreID;
                    break;
                }
            }
        }
    }
}
