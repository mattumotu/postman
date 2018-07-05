namespace Postman.Interfaces
{
    /// <summary>
    /// An <see cref="IEnvelope"/> contains <see cref="IStamp"/>s and <see cref="IEnclosure"/>s and can be unwrapped as a <see cref="System.Net.Mail.MailMessage" />
    /// </summary>
    public interface IEnvelope
    {
        /// <summary>
        /// Unwrap this instance into a <see cref="System.Net.Mail.MailMessage" />
        /// </summary>
        /// <returns>a populated <see cref="System.Net.Mail.MailMessage" /></returns>
        System.Net.Mail.MailMessage Unwrap();
    }
}