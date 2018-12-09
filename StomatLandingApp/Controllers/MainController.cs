using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace StomatLandingApp.Controllers
{
    public class MainController : Controller
    {
        private const string SENDER_EMAIL = "djoni-01@mail.ru";
        private const string SENDER_PASSWORD = "Password";
        private const string RECIPIENT_EMAIL = "djoniqaz@gmail.com";

        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendData(string fullname, string email, string message)
        {
            MailAddress from = new MailAddress(SENDER_EMAIL, fullname);
            MailAddress to = new MailAddress(RECIPIENT_EMAIL);
            MailMessage m = new MailMessage(from, to)
            {
                Subject = "Feedback",
                Body = message
            };
            SmtpClient smpt = new SmtpClient("smtp.mail.ru", 25)
            {
                Credentials = new NetworkCredential(SENDER_EMAIL, SENDER_PASSWORD),
                EnableSsl = true
            };
            smpt.Send(m);
            return View("Index");
        }
    }
}