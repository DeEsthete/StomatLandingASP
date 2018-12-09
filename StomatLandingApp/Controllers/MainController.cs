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
        private const string SENDER_EMAIL = "djoni-01@list.ru";
        private const string SENDER_PASSWORD = "-";
        private const string RECIPIENT_EMAIL = "djoniqaz@gmail.com";

        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SendData(string fullname, string email, string message)//text - название textarea
        {
            SmtpClient Smtp = new SmtpClient("smtp.gmail.com ", 587);
            Smtp.Credentials = new NetworkCredential(SENDER_EMAIL, SENDER_PASSWORD);
            Smtp.EnableSsl = true;
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress(SENDER_EMAIL);
            Message.To.Add(new MailAddress(RECIPIENT_EMAIL));
            Message.Subject = "Feedback";
            Message.Body = "Name: " + fullname + " Email: " + email + "Message: " + message;
            Smtp.Send(Message);
            return View("Index");
        }
    }
}