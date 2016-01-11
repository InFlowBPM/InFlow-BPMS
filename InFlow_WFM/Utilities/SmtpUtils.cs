using strICT.InFlow.Db.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace strICT.InFlow.WFM.Utilities
{
    public class SmtpUtils : IMailUtils
    {
        private const string Email_SMTP_Server = "Email_SMTP_Server";
        private const string Email_SMTP_Port = "Email_SMTP_Port";
        private const string Email_SMTP_MailFrom = "Email_SMTP_MailFrom";

        IConfigStore configStore;
        public SmtpUtils(IConfigStore cStore)
        {
            this.configStore = cStore;
        }
        public void sendMail(string to, string subject, string data)
        {
            if (to.Contains("@strict-solutions.com"))
            {
                SmtpClient client = new SmtpClient(configStore.getString(Email_SMTP_Server), configStore.getInt(Email_SMTP_Port));

                MailAddress mfrom = new MailAddress(configStore.getString(Email_SMTP_MailFrom));
                MailAddress mto = new MailAddress(to);

                MailMessage message = new MailMessage(mfrom, mto);
                message.Body = data;
                message.Subject = subject;
                message.IsBodyHtml = true;
                client.Send(message);
            }
        }
    }
}
