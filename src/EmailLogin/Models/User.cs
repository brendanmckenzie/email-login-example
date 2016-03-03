namespace EmailLogin.Models
{
    public class User
    {
        Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}