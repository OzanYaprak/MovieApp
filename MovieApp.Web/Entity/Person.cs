using System.ComponentModel.DataAnnotations;

namespace MovieApp.Web.Entity
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }

        [Required]
        public string PersonName { get; set; }

        public string PersonBiography { get; set; }

        public string Imdb { get; set; }

        public string HomePage { get; set; }

        public string PlaceOfBirth { get; set; }

        public int UserID { get; set; } //foreign key & unique key


        //NAVİGASYON
        public User User { get; set; }
    }
}
