namespace Postman.Stamp
{
    using System;
    using System.Net.Mail;
    using Postman.Interfaces;

    /// <summary>
    /// Represents an email's Recipient(s)
    /// </summary>
    public class Recipient : IStamp
    {
        /// <summary>
        /// Holds the recipients
        /// </summary>
        private readonly MailAddressCollection emailCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="Recipient" /> class with the specified address(es)
        /// </summary>
        /// <param name="addr">a string containing an email address, or number of addresses separated by ';'</param>
        public Recipient(string addr)
        {
            this.emailCollection = new MailAddressCollection();

            foreach (string addressString in addr.Split(new char[] { ';' }))
            {
                if (!string.IsNullOrWhiteSpace(addressString))
                {
                    this.emailCollection.Add(addressString.Trim());
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Recipient" /> class with the specified MailAddress
        /// </summary>
        /// <param name="addr">a MailAddress containing the email address</param>
        public Recipient(MailAddress addr)
        {
            this.emailCollection = new MailAddressCollection();
            this.emailCollection.Add(addr);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Recipient" /> class with the specified address and display name
        /// </summary>
        /// <param name="addr">a string containing an email address</param>
        /// <param name="dispName">a string containing a display name</param>
        public Recipient(string addr, string dispName)
            : this(new MailAddress(addr, dispName))
        {
        }

        /// <summary>
        /// Attach this instance to the specified message
        /// </summary>
        /// <param name="msg">a MailMessage to attach this instance to</param>
        public void Attach(MailMessage msg)
        {
            foreach (MailAddress addr in this.emailCollection)
            {
                msg.To.Add(addr);
            }
        }
    }
}