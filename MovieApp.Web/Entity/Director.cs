using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Web.Entity
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ImageURL { get; set; }


        //NAVİGASYON
        public Person Person { get; set; }
    }



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



    public class Crew
    {
        public int CrewID { get; set; }

        public int MovieID { get; set; }

        public int PersonID { get; set; }

        public string Job { get; set; }


        //NAVİGASYON
        public Person Person { get; set; }
        public Movie Movie { get; set; }
    }



    public class Cast
    {
        public int CastID { get; set;}

        public int MovieID { get; set;}

        public int PersonID { get; set;}

        public string CastName { get; set; }

        public string CharacterName { get; set;}



        //NAVİGASYON
        public Person Person { get; set; }
        public Movie Movie { get; set; }
    }
}
