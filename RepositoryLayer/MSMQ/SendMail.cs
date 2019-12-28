using System;
using System.Net.Mail;
using Experimental.System.Messaging;

namespace RepositoryLayer.MSMQ
{
    public class SendMail
    {
        public static void SendEmail(string emailId, string token)
        {
            try
            {
                //// get url
                string url = "http://localhost:4200/reset";
                //// get path of queue
                string queueName = @".\Private$\PasswordQueue";

                //// create instance of MessageQueue
                MessageQueue msmq = new MessageQueue(queueName);

                msmq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                ////var message = msMq.Receive().Body;
                var lable = msmq.Receive().Label;
                ////Console.WriteLine(lable + "  " + message);

                Console.WriteLine(lable + " <=Token");
                if (MessageQueue.Exists(queueName))
                {
                    //Console.WriteLine("Queue Read.....");

                    //// create instance of MailMessage
                    MailMessage mail = new MailMessage();
                    mail.IsBodyHtml = true;

                    //// create instance of SmtpClient
                    SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                    //// add the body, subject and other parameteres of mail 
                    mail.From = new MailAddress("giridhardandikwar@gmail.com");
                    mail.To.Add(emailId);
                    mail.Subject = "Test MSMQ and SMTP";
                    mail.Body = "<h4><a href=" + url + "/" + token + "/> Click here</a></h4> to reset the password " + lable + " <=Token";

                    //// assigning port and giving credentials
                    smtpServer.Port = 587;
                    smtpServer.Credentials = new System.Net.NetworkCredential("giridhardandikwar@gmail.com", "sushh_1992");
                    smtpServer.EnableSsl = true;

                    //// send mail
                    smtpServer.Send(mail);
                    //Console.WriteLine("link has been sent to your mail....");
                }
                else
                {
                    //Console.WriteLine("Queue Empty....");
                }

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        }
}
