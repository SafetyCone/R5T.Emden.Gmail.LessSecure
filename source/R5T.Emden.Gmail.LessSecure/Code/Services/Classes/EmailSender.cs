using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;

using R5T.Gimpolis;


namespace R5T.Emden.Gmail.LessSecure
{
    public class EmailSender : IEmailSender
    {
        public const string GmailSmtpServerHostName = "smtp.gmail.com";
        public const int TlsPortNumber = 587;


        private IOptions<GmailAuthentication> GmailAuthentication { get; }


        public EmailSender(IOptions<GmailAuthentication> gmailAuthentication)
        {
            this.GmailAuthentication = gmailAuthentication;
        }

        public void Send(MailMessage message)
        {
            var gmailAuthentication = this.GmailAuthentication.Value;

            var fromAddress = gmailAuthentication.Address;
            var displayName = gmailAuthentication.DisplayName;
            var fromAddressUsername = gmailAuthentication.Username;
            var fromAddressPassword = gmailAuthentication.Password;

            message.From = new MailAddress(fromAddress, displayName);

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

        public async Task SendAsync(MailMessage message)
        {
            var gmailAuthentication = this.GmailAuthentication.Value;

            var fromAddress = gmailAuthentication.Address;
            var displayName = gmailAuthentication.DisplayName;
            var fromAddressUsername = gmailAuthentication.Username;
            var fromAddressPassword = gmailAuthentication.Password;

            message.From = new MailAddress(fromAddress, displayName);

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
    }
}
