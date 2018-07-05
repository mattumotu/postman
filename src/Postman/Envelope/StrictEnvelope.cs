namespace Postman.Envelope
{
    using System;
    using System.Net.Mail;
    using Postman.Interfaces;

    /// <summary>
    /// Represents an envelope with strict criteria for unwrapping
    /// </summary>
    public class StrictEnvelope : IEnvelope
    {
        /// <summary>
        /// Holds the origin envelope
        /// </summary>
        private IEnvelope orgin;

        /// <summary>
        /// Initializes a new instance of the <see cref="StrictEnvelope" /> class decorating the specified origin <see cref="IEnvelope"/>.
        /// </summary>
        /// <param name="env">the origin <see cref="IEnvelope"/></param>
        public StrictEnvelope(IEnvelope env)
        {
            this.orgin = env;
        }

        /// <summary>
        /// Unwrap this instance into a System.Net.Mail.MailMessage
        /// </summary>
        /// <returns>a populated System.Net.Mail.MailMessage</returns>
        /// <exception cref="InvalidOperationException">thrown if the list of recipients is empty</exception>
        /// <exception cref="InvalidOperationException">thrown if the sender is Nothing</exception>
        /// <exception cref="InvalidOperationException">thrown if the subject is Nothing or empty</exception>
        public MailMessage Unwrap()
        {
            MailMessage msg = this.orgin.Unwrap();

            if (msg.To.Count == 0)
            {
                throw new InvalidOperationException("list of recipients is empty");
            }

            if (msg.From == null)
            {
                throw new InvalidOperationException("sender is Nothing");
            }

            if (string.IsNullOrEmpty(msg.Subject))
            {
                throw new InvalidOperationException("subject is Nothing or empty");
            }

            return msg;
        }
    }
}