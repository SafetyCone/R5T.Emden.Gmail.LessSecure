using System;
using System.Net;
using System.Net.Mail;

using Microsoft.Extensions.Options;


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
            var fromAddressUsername = this.GmailAuthentication.Value.Username;
            var fromAddressPassword = this.GmailAuthentication.Value.Password;

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
    }
}
