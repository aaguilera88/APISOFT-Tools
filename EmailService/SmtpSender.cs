using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmailService
{
    public partial class SmtpSender : IEmailSender
    {
        public void SendEmail(string subject, string HtmlContent, string Content, List<EmailAddresses> ToAddress, EmailAddresses FromAddress, List<EmailAttachments> Attachments, EmailConfiguration Config)
        {
            var message = new MimeMessage
            {
                Subject = subject
            };
            message.From.Add(new MailboxAddress(FromAddress.EmailOwner, FromAddress.EmmailAddress));

            foreach(var item in ToAddress)
            {
                message.To.Add(new MailboxAddress(item.EmailOwner, item.EmmailAddress));
            } 
            
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = Content,
                TextBody = Regex.Replace(Content, "<[^>]*>", "")
            };

            foreach(var item in Attachments)
            {
                bodyBuilder.Attachments.Add(item.AttachmentName, item.Attachment);
            }           

            message.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                smtp.Connect(Config.Server, Config.Port, Config.SecurityOption);
                smtp.Authenticate(Config.UserName, Config.Password);
                //Send
                smtp.Send(message);
                smtp.Disconnect(true);
            }
        }

        public async Task SendEmailAsync(string subject, string HtmlContent, string Content, List<EmailAddresses> ToAddress, EmailAddresses FromAddress, List<EmailAttachments> Attachments, EmailConfiguration Config)
        {
            var message = new MimeMessage
            {
                Subject = subject
            };
            message.From.Add(new MailboxAddress(FromAddress.EmailOwner, FromAddress.EmmailAddress));

            foreach (var item in ToAddress)
            {
                message.To.Add(new MailboxAddress(item.EmailOwner, item.EmmailAddress));
            }

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = Content,
                TextBody = Regex.Replace(Content, "<[^>]*>", "")
            };

            foreach (var item in Attachments)
            {
                bodyBuilder.Attachments.Add(item.AttachmentName, item.Attachment);
            }

            message.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                await smtp.ConnectAsync(Config.Server, Config.Port, Config.SecurityOption);
                await smtp.AuthenticateAsync(Config.UserName, Config.Password);
                //Send
                await smtp.SendAsync(message);
                await smtp.DisconnectAsync(true);
            }
        }
    }
}