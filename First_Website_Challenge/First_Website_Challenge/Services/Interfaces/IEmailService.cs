namespace First_Website_Challenge.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(string subject, string senderName, string senderEmail, string body);
    }
}
