namespace Postman.Interfaces
{
    /// <summary>
    /// An <see cref="IEmbeddedResource"/> can be embedded within an HTML Enclosure
    /// </summary>
    public interface IEmbeddedResource
    {
        /// <summary>
        /// Embed this instance in a <see cref="System.Net.Mail.AlternateView"/>
        /// </summary>
        /// <param name="altView">the <see cref="System.Net.Mail.AlternateView"/> to embed this instance in</param>
        void Embed(System.Net.Mail.AlternateView altView);
    }
}