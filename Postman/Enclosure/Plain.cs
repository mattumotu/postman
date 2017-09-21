namespace Postman.Enclosure
{
    using System.Net.Mail;
    using System.Net.Mime;
    using Postman.Interfaces;

    /// <summary>
    /// Represents a plain enclosure
    /// </summary>
    public class Plain : IEnclosure
    {
        /// <summary>
        /// Holds the plain text
        /// </summary>
        private string text;

        /// <summary>
        /// Initializes a new instance of the <see cref="Plain" /> class.
        /// </summary>
        /// <param name="content">a string containing the plain text</param>
        public Plain(string content)
        {
            this.text = content;
        }

        /// <summary>
        /// Include this instance to a <see cref="System.Net.Mail.MailMessage" />
        /// </summary>
        /// <param name="msg">the <see cref="System.Net.Mail.MailMessage" /> to include this instance within</param>
        public void Include(MailMessage msg)
        {
            msg.AlternateViews.Add(
                AlternateView.CreateAlternateViewFromString(
                    this.text,
                    System.Text.Encoding.UTF8,
                    MediaTypeNames.Text.Plain));
        }
    }
}