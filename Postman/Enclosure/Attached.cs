namespace Postman.Enclosure
{
    using System.Net.Mail;
    using Postman.Interfaces;

    /// <summary>
    /// Represents and attached enclosure
    /// </summary>
    public class Attached : IEnclosure
    {
        /// <summary>
        /// Holds the attachment
        /// </summary>
        private Attachment att;

        /// <summary>
        /// Initializes a new instance of the <see cref="Attached" /> class.
        /// </summary>
        /// <param name="content">the attachment to be included</param>
        public Attached(Attachment content)
        {
            this.att = content;
        }

        /// <summary>
        /// Include this instance to a <see cref="System.Net.Mail.MailMessage" />
        /// </summary>
        /// <param name="msg">the System.Net.Mail.MailMessage to be included within</param>
        public void Include(System.Net.Mail.MailMessage msg)
        {
            msg.Attachments.Add(this.att);
        }
    }
}