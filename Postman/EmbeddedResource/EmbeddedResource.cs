namespace Postman.EmbeddedResource
{
    using System.IO;
    using System.Net.Mail;
    using System.Net.Mime;
    using Postman.Interfaces;

    /// <summary>
    /// An <see cref="IEmbeddedResource"/> which can be embedded within a <see cref="SMTPPostman.Enclosure.Html"/>
    /// </summary>
    public class EmbeddedResource : IEmbeddedResource
    {
        /// <summary>
        /// Holds the resource
        /// </summary>
        private LinkedResource res;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedResource" /> class.
        /// </summary>
        /// <param name="content">a stream containing the resource</param>
        /// <param name="type">the content type of the resource</param>
        public EmbeddedResource(Stream content, ContentType type)
        {
            this.res = new LinkedResource(content, type);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedResource" /> class.
        /// </summary>
        /// <param name="fileName">a string containing the resource filename</param>
        /// <param name="type">the content type of the resource</param>
        public EmbeddedResource(string fileName, ContentType type)
        {
            this.res = new LinkedResource(fileName, type);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbeddedResource" /> class.
        /// </summary>
        /// <param name="content">a stream containing the resource</param>
        /// <param name="type">the content type of the resource</param>
        /// <param name="contentId">a string containing a reference id for this resource</param>
        public EmbeddedResource(Stream content, ContentType type, string contentId)
        {
            this.res = new LinkedResource(content, type);
            this.res.ContentId = contentId;
        }

        /// <summary>
        /// /// Initializes a new instance of the <see cref="EmbeddedResource" /> class.
        /// </summary>
        /// <param name="fileName">a string containing the resource filename</param>
        /// <param name="type">the content type of the resource</param>
        /// <param name="contentId">a string containing a reference id for this resource</param>
        public EmbeddedResource(string fileName, ContentType type, string contentId)
        {
            this.res = new LinkedResource(fileName, type);
            this.res.ContentId = contentId;
        }

        /// <summary>
        /// Embed this instance in a <see cref="System.Net.Mail.AlternateView"/>
        /// </summary>
        /// <param name="altView">the <see cref="System.Net.Mail.AlternateView"/> to embed this instance in</param>
        public void Embed(System.Net.Mail.AlternateView altView)
        {
            altView.LinkedResources.Add(this.res);
        }
    }
}