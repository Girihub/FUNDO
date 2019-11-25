//----------------------------------------------------
// <copyright file="SendMessage.cs" company="Bridgelabz">
// Company copyright tag.
// </copyright>
//----------------------------------------------------

namespace RepositoryLayer.MSMQ
{
    using Experimental.System.Messaging;

    /// <summary>
    /// SendMessage as a class
    /// </summary>
    public class SendMessage
    {
        /// <summary>
        /// ForgotPasswordMessage as a method
        /// </summary>
        /// <param name="email">email as a parameter</param>
        /// <param name="token">token as a parameter</param>
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

            messageQueue.Send(email, token);
        }
    }
}
