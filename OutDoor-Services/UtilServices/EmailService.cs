using OutDoor_Models.Services;
using System;
using System.Net;
using System.Net.Mail;

public class EmailService : IEmailService
{

    public void sendEmail(String email, String subject, String body, bool ishtml = false)
    {

        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("outdoor.dontreply@gmail.com");
        mail.To.Add(email);
        mail.Subject = subject;
        mail.Body = body;
        mail.IsBodyHtml = ishtml;

        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

        smtp.Credentials = new NetworkCredential("outdoor.dontreply@gmail.com", "izumyvaxtprcsceu");
        smtp.EnableSsl = true;
        smtp.Send(mail);


    }
}