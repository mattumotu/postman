namespace Postman.Interfaces
{
    /// <summary>
    /// An <see cref="IEnclosure"/> can be included in an <see cref="IEnvelope"/>
    /// </summary>
    public interface IEnclosure
    {
        /// <summary>
        /// Include this instance to a <see cref="System.Net.Mail.MailMessage" />
        /// </summary>
        /// <param name="msg">the <see cref="System.Net.Mail.MailMessage" /> to include this instance within</param>
        void Include(System.Net.Mail.MailMessage msg);
    }
}