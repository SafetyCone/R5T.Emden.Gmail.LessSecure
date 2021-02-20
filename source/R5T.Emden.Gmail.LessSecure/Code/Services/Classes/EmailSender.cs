using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using R5T.Gimpolis;


namespace R5T.Emden.Gmail.LessSecure
{
    public class EmailSender : IEmailSender
    {
        public const string GmailSmtpServerHostName = "smtp.gmail.com";
        public const int TlsPortNumber = 587;


        private IOptions<GmailAuthentication> GmailAuthentication { get; }
        private ILogger Logger { get; }


        public EmailSender(
            IOptions<GmailAuthentication> gmailAuthentication,
            ILogger<EmailSender> logger)
        {
            this.GmailAuthentication = gmailAuthentication;
            this.Logger = logger;
        }

        public void Send(MailMessage message)
        {
            var gmailAuthentication = this.GmailAuthentication.Value;

            var fromAddress = gmailAuthentication.Address;
            var displayName = gmailAuthentication.DisplayName;
            var fromAddressUsername = gmailAuthentication.Username;
            var fromAddressPassword = gmailAuthentication.Password;

            message.From = new MailAddress(fromAddress, displayName);

            try
            {
                using (var smtpClient = new SmtpClient()
                {
                    Host = @"smtp.gmail.com",
                    Port = 587,
                    Credentials = new NetworkCredential(fromAddressUsername, fromAddressPassword),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                })
                {
                    smtpClient.Send(message);
                }
            }
            catch (Exception exception)
            {
                this.Logger.LogError(exception, "Failed to send email.");

                throw exception; // Re-throw.
            }
        }

        public async Task SendAsync(MailMessage message)
        {
            var gmailAuthentication = this.GmailAuthentication.Value;

            var fromAddress = gmailAuthentication.Address;
            var displayName = gmailAuthentication.DisplayName;
            var fromAddressUsername = gmailAuthentication.Username;
            var fromAddressPassword = gmailAuthentication.Password;

            message.From = new MailAddress(fromAddress, displayName);

            try
            {
                using (var smtpClient = new SmtpClient()
                {
                    Host = @"smtp.gmail.com",
                    Port = 587,
                    Credentials = new NetworkCredential(fromAddressUsername, fromAddressPassword),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                })
                {
                    await smtpClient.SendMailAsync(message);
                }
            }
            catch (Exception exception)
            {
                this.Logger.LogError(exception, "Failed to send email.");

                throw exception; // Re-throw.
            }
        }
    }
}
