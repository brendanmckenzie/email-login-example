namespace EmailLogin.Web.Models
{
    public class ChallengeRequest
    {
        public string Email { get; set; }
        public string PublicKey { get; set; }
    }
}