using System;
using System.Collections.Generic;
using MovieApp.Web.Entity;

namespace MovieApp.Web.ViewModels
{
    public class MoviesViewModel
    {
        public List<Movie> Movies { get; set; }

        internal MoviesViewModel Where(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
