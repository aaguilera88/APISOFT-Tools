using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    public interface IEmailSender
    {
        void SendEmail(string subject, string HtmlContent, string Content, List<EmailAddresses> ToAddress, EmailAddresses FromAddress, List<EmailAttachments> Attachments, EmailConfiguration Config);
        Task SendEmailAsync(string subject, string HtmlContent, string Content, List<EmailAddresses> ToAddress, EmailAddresses FromAddress, List<EmailAttachments> Attachments, EmailConfiguration Config);
    }
}
