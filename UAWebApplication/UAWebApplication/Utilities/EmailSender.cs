using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace UAWebApplication.Utilities
{
    public class EmailSender
    {

       
        public static bool Send(string To, string Subject, string Body)
        {
            //SmtpClient client = new SmtpClient("smtp.gmail.com");
            //client.Port = 465;
            //client.UseDefaultCredentials = false;
            //client.Credentials = new NetworkCredential("uat98932", "kartik3110");
            //MailMessage mailMessage = new MailMessage();
            //mailMessage.From = new MailAddress("uat98932@gmail.com");
            //mailMessage.To.Add(To);
            //mailMessage.Body = Body;
            //mailMessage.Subject = Subject;
            //client.Send(mailMessage);

            var message = new MailMessage();
            message.To.Add(new MailAddress(To));
            message.From = new MailAddress("uat98932@gmail.com", "UA Test");
            message.Subject = Subject;
            message.IsBodyHtml = true;
            message.Body = Body;
            try
            {
                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "uat98932@gmail.com",
                        Password = "kartik3110"
                    };
                    smtp.Credentials = credential;
                    smtp.DeliveryFormat = SmtpDeliveryFormat.International;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
