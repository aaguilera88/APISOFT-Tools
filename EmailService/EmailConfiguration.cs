using System;
using System.Collections.Generic;
using System.Text;

namespace EmailService
{
    public class EmailConfiguration
    {
        public string Server { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool Security { get; set; }
        public MailKit.Security.SecureSocketOptions SecurityOption { get; set; }
    }
}
