using MovieApp.Web.Entity;
using System.Collections.Generic;

namespace MovieApp.Web.ViewModels
{
    public class AdminMoviesViewModel
    {
        public List<AdminMovieViewModel> Movies { get; set; }
    }


    public class AdminMovieViewModel
    {
        public int MovieID { get; set; }

        public string Title { get; set; }

        public string ImageURL { get; set; }

        public List<Genre> Genres { get; set; }
    }

    public class AdminEditMovieViewModel
    {
        public int MovieID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public List<Genre> SelectedGenres { get; set; }

    }
}
