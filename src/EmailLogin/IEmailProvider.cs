namespace EmailLogin
{
    public interface IEmailProvider
    {
        void SendEmail(string subject, string body, string recipient, string sender);
    }
}