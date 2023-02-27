namespace MovieApp.Web.Entity
{
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
}
