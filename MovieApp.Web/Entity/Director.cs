using System.ComponentModel.DataAnnotations;

namespace MovieApp.Web.Entity
{
    public class Director
    {
        [Key]
        public int DirectorID { get; set; }

        [Required]
        public string DirectorName { get; set; }

        public string ImageURL { get; set; }

        public string Biography { get; set; }
    }
}
