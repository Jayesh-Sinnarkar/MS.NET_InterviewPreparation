using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EmailNotifier.Controllers
{
    public class EmailController : Controller
    {
            public ActionResult EmailDescription()
            {
                return View();
            }

            [HttpPost]
            public ActionResult SendEmail(string txtParagraph)
            {
                string userEmail = "jayesh.sinnarkar.work@gmail.com"; // Replace with the recipient's email address
                string subject = "Email from ASP.NET Web Application";

                try
                {
                    using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                    {
                        smtpClient.Credentials = new NetworkCredential("jayesh.sinnarkar@gmail.com", "5278d5c19F@");
                        smtpClient.EnableSsl = true;
                        smtpClient.Port = 587;

                        MailMessage mailMessage = new MailMessage("jayesh.sinnarkar@gmail.com", userEmail, subject, txtParagraph);
                        mailMessage.IsBodyHtml = false;

                        smtpClient.Send(mailMessage);
                    }

                    // Optionally, you can redirect the user to another page or return a success message.
                    return RedirectToAction("EmailSent");
                }
                catch (Exception ex)
                {
                    // Handle exceptions, e.g., log the error or display an error message to the user.
                    ViewBag.Error = "Error sending email: " + ex.Message;
                    return View("EmailDescription");
                }
            }

            public ActionResult EmailSent()
            {
                return View();
            }
        
    }
}