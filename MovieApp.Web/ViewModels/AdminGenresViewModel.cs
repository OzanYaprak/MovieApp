using System.Collections.Generic;

namespace MovieApp.Web.ViewModels
{
    public class AdminGenresViewModel
    {
        public List<AdminGenreViewModel> Genres { get; set; }
    }

    public class AdminGenreViewModel
    {
        public int GenreID { get; set; }

        public string GenreName { get; set; }

        public int Count { get; set; }

    }
}
