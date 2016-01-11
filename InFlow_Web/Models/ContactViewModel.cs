using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Net.Mail;
namespace strICT.InFlow.Web.Models
{
    public class ContactViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Company { get; set; }

        
        public string PromoCode { get; set; }
    }
    public class Contact
    {
        public string Mail { get; set; }

        public string Name { get; set; }
        
        public string Company { get; set; }


        public string PromoCode { get; set; }
    }
    public class Email
    {
        public void Send(Contact contact)
        {
            string subject = "Request for free InFlow Trial";
            string message = "<p>Name: " + contact.Name+"</p><p>Company/Organization: "+contact.Company+"</p><p>Promotion Code: "+contact.PromoCode+"</p>";
            MailMessage mail = new MailMessage(
                contact.Mail,
                Properties.Settings.Default.ToEmail,
              subject,
                message);
            mail.IsBodyHtml = true;
            SmtpClient mailClient = new SmtpClient(Properties.Settings.Default.SMTPHostname, Convert.ToInt32(587));
            mailClient.Credentials = new System.Net.NetworkCredential(Properties.Settings.Default.SMTPUsername, Properties.Settings.Default.SMTPPassword);
            mailClient.Send(mail);

            string response = "<p>Dear "+contact.Name+"!</p><p>Thank you for your interest in a free InFlow trial version. We will process your request and contact you accordingly.</p><p>Yours sincerely,</p><p>StrICT Solutions Service Team</p>";
            mail = new MailMessage(
                            Properties.Settings.Default.ToEmail,
                            contact.Mail,
                          subject,
                            response);
            mail.IsBodyHtml = true;
            mailClient = new SmtpClient(Properties.Settings.Default.SMTPHostname, Convert.ToInt32(587));
            mailClient.Credentials = new System.Net.NetworkCredential(Properties.Settings.Default.SMTPUsername, Properties.Settings.Default.SMTPPassword);
            mailClient.Send(mail);




        }
    }
}