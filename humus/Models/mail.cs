using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace humus.Models
{
    public class mail
    {
        public string send(order model, DirectoryInfo directory, string file)
        {
            string fileName = "";
            MailAddress fromMail = new MailAddress("hummus2244@gmail.com");

            if (directory != null)
            {
                fileName = directory.FullName + @"\" + file;
            }

            using (MailMessage mail = new MailMessage())
            {
                mail.To.Add(new MailAddress(model.email));
                mail.CC.Add(new MailAddress("oriher2244@gmail.com"));
                mail.Bcc.Add(new MailAddress("bennyhrs@gmail.com"));
                mail.From = fromMail;
                mail.Subject = "תודה על הזמתנך! חומוס עד הבית" ;
                string body = "תודה על הזמתנך " + model.name + "<br>";
                body += "ניצור עמך קשר בהקדם." + "<br>";
                body += "בתיאבון (-:" + "<br>";
                mail.Body = ("<div style='direction:rtl'>" + body + "</div>");
                mail.IsBodyHtml = true;
                if (file != null)
                {
                    Attachment data = new Attachment(fileName, MediaTypeNames.Application.Octet);
                    // Add time stamp information for the file.
                    ContentDisposition disposition = data.ContentDisposition;
                    disposition.CreationDate = System.IO.File.GetCreationTime(fileName);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(fileName);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(fileName);
                    data.Name = model.name + ".pdf";
                    mail.Attachments.Add(data);
                }

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential networkCredential = new NetworkCredential(fromMail.ToString(), "orielkana");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCredential;
                smtp.Port = 587;
                smtp.Send(mail);

                return "OK";
            }
        }
    }
}