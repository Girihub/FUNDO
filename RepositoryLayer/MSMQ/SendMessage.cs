using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.MSMQ
{
    public class SendMessage
    {
        public static void ForgotPasswordMessage(string email, string token)
        {
            MessageQueue messageQueue = null;
            if (MessageQueue.Exists(@".\Private$\PasswordlQueue"))
            {
                messageQueue = new MessageQueue(@".\Private$\PasswordlQueue");
                messageQueue.Label = "Testing Queue";
            }
            else
            {
                // Create the Queue
                MessageQueue.Create(@".\Private$\PasswordlQueue");
                messageQueue = new MessageQueue(@".\Private$\PasswordlQueue");
                messageQueue.Label = "Newly Created Queue";
            }
            messageQueue.Send(email,token);
        }
    }
}
