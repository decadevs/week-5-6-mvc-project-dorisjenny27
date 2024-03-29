using First_Website_Challenge.Services.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace First_Website_Challenge.Services
{
public class EmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmail(string senderName, string subject, string senderEmail, string body)
    {
        var recipientEmail = _configuration["EmailSettings:RecipientEmail"];
        var password = _configuration["EmailSettings:AppPassword"];
        var smtpHost = _configuration["EmailSettings:Host"];
        var port = _configuration["EmailSettings:Port"];
        var email = new MimeMessage();
        email.From.Add(new MailboxAddress(senderName, recipientEmail));
        email.To.Add(new MailboxAddress("", senderEmail));
        email.Subject = subject;
        email.Body = new TextPart("plain") { Text = body };

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(smtpHost, int.Parse(port), true);
            await client.AuthenticateAsync(recipientEmail, password);
            await client.SendAsync(email);
            await client.DisconnectAsync(true);
        }


    }


}

}


