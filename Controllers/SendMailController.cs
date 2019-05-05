using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Net.Mail;


namespace SendMailwithAttachment.Controllers
{

    public class SendMailerController : Controller

    {

        public ActionResult Index()

        {

            return View();

        }


        /// <param name="objModelMail">MailModel Object, keeps all properties</param>

        /// <param name="fileUploader">Selected file data, example-filename,content,content type(file type- .txt,.png etc.),length etc.</param>

        /// <returns></returns>

        [HttpPost]

        public ActionResult Index(Sprint0.Models.SendEmail objModelMail, HttpPostedFileBase fileUploader)

        {

            if (ModelState.IsValid)

            {

                string from = "Autobots3019@gmail.com";

                using (MailMessage mail = new MailMessage(from, objModelMail.To))

                {

                    mail.Subject = objModelMail.Subject;

                    mail.Body = objModelMail.Body;

                    if (fileUploader != null)

                    {

                        string fileName = Path.GetFileName(fileUploader.FileName);

                        mail.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));

                    }

                    mail.IsBodyHtml = false;

                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.EnableSsl = true;

                    NetworkCredential networkCredential = new NetworkCredential(from, "Autobots1$");

                    smtp.UseDefaultCredentials = true;

                    smtp.Credentials = networkCredential;

                    smtp.Port = 587;

                    smtp.Send(mail);

                    ViewBag.Message = "Sent";

                    return View("Index", objModelMail);

                }

            }

            else

            {

                return View();

            }

        }

    }

}
