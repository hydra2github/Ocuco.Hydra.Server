//using System;
//using System.IO;
//using MailKit;
//using MailKit.Net.Smtp;
//using Microsoft.Extensions.Logging;
//using MimeKit;
//using RestSharp;
//using RestSharp.Authenticators;

namespace Ocuco.Application.Services.OcucoHub.MailService
{
    //public class SmtpClientMailService : IMailService
    //{
    //    private readonly ILogger<SmtpClientMailService> logger;

    //    public SmtpClientMailService(ILogger<SmtpClientMailService> logger)
    //    {
    //        this.logger = logger;
    //    }

    //    public void SendMessage(string to, string subject, string body)
    //    {
    //        // Log the message
    //        logger.LogInformation($"To: {to} Subject: {subject} Body: {body}");


    //        //try
    //        //{
    //        //    MimeMessage mail = new MimeMessage();
    //        //    mail.From.Add(new MailboxAddress("Hydra Admin", "daniel.tassi@ocuco.com"));
    //        //    mail.To.Add(new MailboxAddress("User", to));
    //        //    mail.Subject = subject;
    //        //    mail.Body = new TextPart("plain")
    //        //    {
    //        //        //Text = @"Testing some Mailgun awesomesauce!",
    //        //        Text = body,
    //        //    };


    //        //    // Send it!
    //        //    using (var client = new SmtpClient())
    //        //    {
    //        //        // XXX - Should this be a little different?
    //        //        //client.ServerCertificateValidationCallback = (s, c, h, e) => true;

    //        //        client.Connect("in-v3.mailjet.com", 587, false);
    //        //        //client.AuthenticationMechanisms.Remove("XOAUTH2");
    //        //        client.Authenticate("608327e21253bdbbcea1e6c2326a2f1b", "7214eb1615f9d859e553a53c5d16515f");

    //        //        client.Send(mail);
    //        //        client.Disconnect(true);
    //        //    }
    //        //}
    //        //catch (Exception ex)
    //        //{

    //        //    throw;
    //        //}



    //        //try
    //        //{
    //        //    // Compose a message
    //        //    MimeMessage mail = new MimeMessage();
    //        //    mail.From.Add(new MailboxAddress("Excited Admin", "foo@mg.hydrahub.com"));
    //        //    mail.To.Add(new MailboxAddress("Excited User", to));
    //        //    mail.Subject = subject;
    //        //    mail.Body = new TextPart("plain")
    //        //    {
    //        //        //Text = @"Testing some Mailgun awesomesauce!",
    //        //        Text = body,
    //        //    };

    //        //    // Send it!
    //        //    using (var client = new SmtpClient())
    //        //    {
    //        //        // XXX - Should this be a little different?
    //        //        client.ServerCertificateValidationCallback = (s, c, h, e) => true;

    //        //        client.Connect("smtp.mailgun.org", 587, false);
    //        //        client.AuthenticationMechanisms.Remove("XOAUTH2");
    //        //        client.Authenticate("daniel.tassi@ocuco.com", "OcucoTest2018!MG");

    //        //        client.Send(mail);
    //        //        client.Disconnect(true);
    //        //    }
    //        //}
    //        //catch (Exception ex)
    //        //{

    //        //    throw;
    //        //}


    //        ////var smtpClient = new SmtpClient
    //        ////{
    //        ////    Host = "smtp.gmail.com", // set your SMTP server name here
    //        ////    Port = 587, // Port 
    //        ////    EnableSsl = true,
    //        ////    Credentials = new NetworkCredential("oltreverso.oim@gmail.com", "dt2012**oim")               
    //        ////};
            
    //        ////using (var message = new MailMessage("oltreverso.oim@gmail.com", to)
    //        ////{
    //        ////    Subject = subject,
    //        ////    Body = body
    //        ////})
    //        ////{
    //        ////    //await smtpClient.SendMailAsync(message);
    //        ////    smtpClient.Send(message);
    //        ////}


    //        ////var client = new SmtpClient("smtp.gmail.com", 587);
    //        ////client.UseDefaultCredentials = false;
    //        ////client.Credentials = new NetworkCredential("oltreverso.oim@gmail.com", "dt2012**oim");
    //        ////client.EnableSsl = true;

    //        ////MailMessage mailMessage = new MailMessage();
    //        ////mailMessage.From = new MailAddress("oltreverso.oim@gmail.com");
    //        ////mailMessage.To.Add(to);
    //        ////mailMessage.Body = body;
    //        ////mailMessage.Subject = subject;

    //        ////client.Send(mailMessage);

    //    }


    //    //public static RestResponse SendSimpleMessage()
    //    //{
    //    //    RestClient client = new RestClient();
    //    //    client.BaseUrl = "https://api.mailgun.net/v3";
    //    //    client.Authenticator =
    //    //        new HttpBasicAuthenticator("api", "c45f5f7573fcbd03b69624e0a072a550-0e6e8cad-db3c5a4f");
    //    //    RestRequest request = new RestRequest();
    //    //    request.AddParameter("domain", "sandbox255b803e81184574829b523ce8014791.mailgun.org", ParameterType.UrlSegment);
    //    //    request.Resource = "{domain}/messages";
    //    //    request.AddParameter("from", "Mailgun Sandbox <postmaster@sandbox255b803e81184574829b523ce8014791.mailgun.org>");
    //    //    request.AddParameter("to", "Daniel Tassi <daniel.tassi@ocuco.com>");
    //    //    request.AddParameter("subject", "Hello Daniel Tassi");
    //    //    request.AddParameter("text", "Congratulations Daniel Tassi, you just sent an email with Mailgun!  You are truly awesome!");
    //    //    request.Method = Method.POST;
    //    //    return client.Execute(request);
    //    //}




    //}
}
