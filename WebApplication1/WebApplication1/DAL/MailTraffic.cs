using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public static class MailTraffic
    {
        static string fromMailAddres = "     @aol.com";     // e-mail
        static string toMailAddres = "      @aol.com";
        // smpt settings in web.config

        public static void SendEmailBasePerson(PersonBase person)
        {
            MailMessage mailMessage = new MailMessage(fromMailAddres, toMailAddres);
            mailMessage.Subject = "Post Report";
            mailMessage.Body = person.ToString();

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(mailMessage);
        }

        public static void SendEmailFullPerson(PersonFull person)
        {
            MailMessage mailMessage = new MailMessage(fromMailAddres, toMailAddres);
            mailMessage.Subject = "Post Report";
            mailMessage.Body = person.ToString();

            SmtpClient smtpClient = new SmtpClient();
            
            smtpClient.Send(mailMessage);
        }
    }
}