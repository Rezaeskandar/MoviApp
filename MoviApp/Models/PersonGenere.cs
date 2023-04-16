namespace MoviApp.Models
{
    public class PersonGenere
    {
        public int personGenereId { get; set; }
        public List<Person>? PersonList { get; set; } = new List<Person>();
        public List<Genre>? GenerList { get; set; } = new List<Genre>();
    }
}
