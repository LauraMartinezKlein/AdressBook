namespace appAddress.Models
{

    public enum TypeContact
    {
        telephone,
        email,
        facebook,
        twitter,
        instagram,
        dblink
    }
    public class Book
    {
        public int BookID { get; set; }
        public string name { get; set; }
        public TypeContact type { get; set; }
        public string contact { get; set; }
    }
}