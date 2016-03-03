namespace EmailLogin.Web.Models
{
    public class ChallengeResponse : BaseRespose
    {
        public string PublicKey { get; set; }

        public string Token { get; set; }
        public Guid Id { get; set; }
    }
}