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
}
