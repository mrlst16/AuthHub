﻿using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Xunit;

namespace AuthHub.BLL.Common.Tests
{
    public class EmailTests
    {
        [Fact]
        public async Task SendEmailTry()
        {
            // Replace sender@example.com with your "From" address. 
            // This address must be verified with Amazon SES.
            String FROM = "verifications@mattylantz.com";
            String FROMNAME = "Sender Name";

            // Replace recipient@example.com with a "To" address. If your account 
            // is still in the sandbox, this address must be verified.
            String TO = "mrlst16@mail.rmu.edu";

            // Replace smtp_username with your Amazon SES SMTP user name.
            String SMTP_USERNAME = "AKIAW6KNALHHOIPJ5D27";

            // Replace smtp_password with your Amazon SES SMTP password.
            String SMTP_PASSWORD = "BCKTgKGnZ8o3HzkrcHBNkWLNyTKTsmcnXmvoZ8fNGARA";

            // (Optional) the name of a configuration set to use for this message.
            // If you comment out this line, you also need to remove or comment out
            // the "X-SES-CONFIGURATION-SET" header below.
            String CONFIGSET = "ConfigSet";

            // If you're using Amazon SES in a region other than US West (Oregon), 
            // replace email-smtp.us-west-2.amazonaws.com with the Amazon SES SMTP  
            // endpoint in the appropriate AWS Region.
            String HOST = "email-smtp.us-east-2.amazonaws.com";

            // The port you will connect to on the Amazon SES SMTP endpoint. We
            // are choosing port 587 because we will use STARTTLS to encrypt
            // the connection.
            int PORT = 587;

            // The subject line of the email
            String SUBJECT =
                "Amazon SES test (SMTP interface accessed using C#)";

            // The body of the email
            String BODY =
                "<h1>Amazon SES Test</h1>" +
                "<p>This email was sent through the " +
                "<a href='https://aws.amazon.com/ses'>Amazon SES</a> SMTP interface " +
                "using the .NET System.Net.Mail library.</p>";

            // Create and build a new MailMessage object
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(FROM, FROMNAME);
            message.To.Add(new MailAddress(TO));
            message.Subject = SUBJECT;
            message.Body = BODY;
            // Comment or delete the next line if you are not using a configuration set
            //message.Headers.Add("X-SES-CONFIGURATION-SET", CONFIGSET);

            using (var client = new System.Net.Mail.SmtpClient(HOST, PORT))
            {
                // Pass SMTP credentials
                client.Credentials =
                    new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                // Enable SSL encryption
                client.EnableSsl = true;

                // Try to send the message. Show status in console.
                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}