namespace Postman.Interfaces
{
    /// <summary>
    /// An <see cref="IStamp"/> can be applied to an <see cref="IEnvelope"/>
    /// </summary>
    public interface IStamp
    {
        /// <summary>
        /// Attach this stamp to the supplied <see cref="System.Net.Mail.MailMessage" />
        /// </summary>
        /// <param name="msg">the <see cref="System.Net.Mail.MailMessage" /> to attach this stamp to</param>
        void Attach(System.Net.Mail.MailMessage msg);
    }
}