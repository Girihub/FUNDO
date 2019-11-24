using Experimental.System.Messaging;

namespace RepositoryLayer.MSMQ
{
    public class SendMessage
    {
        public static void ForgotPasswordMessage(string email, string token)
        {
            MessageQueue messageQueue = null;
            if (MessageQueue.Exists(@".\Private$\PasswordQueue"))
            {
                messageQueue = new MessageQueue(@".\Private$\PasswordQueue");
                messageQueue.Label = "Testing Queue";
            }
            else
            {
                // Create the Queue
                MessageQueue.Create(@".\Private$\PasswordQueue");
                messageQueue = new MessageQueue(@".\Private$\PasswordQueue");
                messageQueue.Label = "Newly Created Queue";
            }
            messageQueue.Send(email,token);
        }
    }
}
