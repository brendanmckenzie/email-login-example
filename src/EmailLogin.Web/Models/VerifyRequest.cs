namespace EmailLogin.Web.Models
{
    public class VerifyRequest
    {
        public Guid Id { get; set; }
        public string Token { get; set; }

    }
}