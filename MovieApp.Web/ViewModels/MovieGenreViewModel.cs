using System.Collections.Generic;
using MovieApp.Web.Models;

namespace MovieApp.Web.ViewModels
{
    public class MovieGenreViewModel
    {
        public List<Movie> Movies { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
