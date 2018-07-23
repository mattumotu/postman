namespace Postman.Stamp
{
    using System.Net.Mail;
    using Postman.Interfaces;

    /// <summary>
    /// Represents a subject stamp
    /// </summary>
    public class Subject : IStamp
    {
        /// <summary>
        /// Hold the subject
        /// </summary>
        private readonly string subject;

        /// <summary>
        /// Initializes a new instance of the <see cref="Subject" /> class.
        /// </summary>
        /// <param name="subj">a string containing the subject</param>
        public Subject(string subj)
        {
            this.subject = subj;
        }

        /// <summary>
        /// Attach this instance to a System.Net.Mail.MailMessage
        /// </summary>
        /// <param name="msg">the System.Net.Mail.MailMessage to attach this instance to</param>
        public void Attach(MailMessage msg)
        {
            msg.Subject = this.subject;
        }
    }
}
