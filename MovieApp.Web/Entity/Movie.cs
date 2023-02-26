using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieApp.Web.Entity
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public string Director { get; set; }

        public string ImageURL { get; set; }

        [Required]
        public int GenreID { get; set; }

    }
}
