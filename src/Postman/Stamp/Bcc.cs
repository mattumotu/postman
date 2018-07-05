namespace Postman.Stamp
{
    using System.Net.Mail;
    using Postman.Interfaces;

    /// <summary>
    /// Represents a blind carbon copy stamp
    /// </summary>
    public class Bcc : IStamp
    {
        /// <summary>
        /// Holds the email collection
        /// </summary>
        private MailAddressCollection emailCollection = new MailAddressCollection();

        /// <summary>
        /// Initializes a new instance of the <see cref="Bcc" /> class.
        /// </summary>
        /// <param name="addr">a string holding the address, or list of addresses separated by ';', to be bcc'd</param>
        public Bcc(string addr)
        {
            foreach (string addressString in addr.Split(new char[] { ';' }))
            {
                if (!string.IsNullOrWhiteSpace(addressString))
                {
                    this.emailCollection.Add(addressString.Trim());
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bcc" /> class.
        /// </summary>
        /// <param name="addr">a System.Net.Mail.MailAddress containing the email address to BCC</param>
        public Bcc(MailAddress addr)
        {
            this.emailCollection.Add(addr);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bcc" /> class.
        /// </summary>
        /// <param name="addr">a string holding the address to be bcc'd</param>
        /// <param name="dispName">a string holding the display name to be bcc'd</param>
        public Bcc(string addr, string dispName)
            : this(new MailAddress(addr, dispName))
        {
        }

        /// <summary>
        /// Attach this instance to a System.Net.Mail.MailMessage
        /// </summary>
        /// <param name="msg">the System.Net.Mail.MailMessage to attach this instance to</param>
        public void Attach(MailMessage msg)
        {
            foreach (MailAddress addr in this.emailCollection)
            {
                msg.Bcc.Add(addr);
            }
        }
    }
}