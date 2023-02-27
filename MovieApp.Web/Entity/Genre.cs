using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Web.Entity
{
    public class Genre
    {
        [Key]
        public int GenreID { get; set; }

        [Required]
        public string GenreName { get; set; }


        //NAVİGASYON

        public List<Movie> Movies { get; set; }

    }
}
