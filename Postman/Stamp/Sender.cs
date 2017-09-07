namespace Postman.Stamp
{
    using System.Net.Mail;

    /// <summary>
    /// Represents a sender stamp
    /// </summary>
    public class Sender : IStamp
    {
        /// <summary>
        /// Holds the sender
        /// </summary>
        private MailAddress email;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sender" /> class with the specified address(es)
        /// </summary>
        /// <param name="addr">a string containing an email address, or number of addresses separated by ';'</param>
        public Sender(string addr)
        {
            this.email = new MailAddress(addr);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sender" /> class with the specified MailAddress
        /// </summary>
        /// <param name="addr">a MailAddress containing the email address</param>
        public Sender(MailAddress addr)
        {
            this.email = addr;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sender" /> class with the specified address and display name
        /// </summary>
        /// <param name="addr">a string containing an email address</param>
        /// <param name="dispName">a string containing a display name</param>
        public Sender(string addr, string dispName)
            : this(new MailAddress(addr, dispName))
        { }

        /// <summary>
        /// Attach this instance to the specified message
        /// </summary>
        /// <param name="msg">a MailMessage to attach this instance to</param>
        public void Attach(MailMessage msg)
        {
            msg.Sender = this.email;
            msg.From = this.email;
        }
    }
}