namespace Users.Models
{
    public class SignUp
    {
        public Guid id { get; init; }
        public string name { get; set; }
        public string email { get; set; }
        public string  password{ get; set; }
    }
}