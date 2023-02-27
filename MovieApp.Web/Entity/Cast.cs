namespace MovieApp.Web.Entity
{
    public class Cast
    {
        public int CastID { get; set; }

        public int MovieID { get; set; }

        public int PersonID { get; set; }

        public string CastName { get; set; }

        public string CharacterName { get; set; }



        //NAVİGASYON
        public Person Person { get; set; }
        public Movie Movie { get; set; }
    }
}
