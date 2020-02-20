using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace YeldaSert.Email
{
    public class Email
    {
        public static void SendEposta(string subject,string body,string to)
        {
            try
            {
                var fromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
                var fromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
                var fromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
                var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
                var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();

               // string body = "Your registration has been done successfully. Thank you.";//mesaj içeriği

                //client.Send(message);
                MailMessage mm = new MailMessage(to, to);//mail kime gitcekse onun mail adresi
                mm.Subject = subject;//konu
                mm.Body = body;//Olumlu olumsuz dönüş 

                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(fromEmailAddress, fromEmailPassword);//senin email şifren
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);

            }
            catch (Exception ex)
            {

            }
        }
    }
}