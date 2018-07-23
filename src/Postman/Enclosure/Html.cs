namespace Postman.Enclosure
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mail;
    using System.Net.Mime;
    using Postman.Interfaces;

    /// <summary>
    /// Represents an html enclosure
    /// </summary>
    public class Html : IEnclosure
    {
        /// <summary>
        /// Holds the HTML text
        /// </summary>
        private readonly string text;

        /// <summary>
        /// Holds the embedded resources
        /// </summary>
        private IEnumerable<IEmbeddedResource> embeddedResList;

        /// <summary>
        /// Initializes a new instance of the <see cref="Html" /> class.
        /// </summary>
        /// <param name="content">a string containing the html</param>
        /// <param name="embeddedResourceList">a list of embedded resources</param>
        public Html(string content, IEnumerable<IEmbeddedResource> embeddedResourceList)
        {
            this.text = content;
            this.embeddedResList = embeddedResourceList;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Html" /> class.
        /// </summary>
        /// <param name="content">a string containing the html</param>
        public Html(string content)
            : this(content, Enumerable.Empty<IEmbeddedResource>())
        {
        }

        /// <summary>
        /// Include this instance to a <see cref="System.Net.Mail.MailMessage" />
        /// </summary>
        /// <param name="msg">the <see cref="System.Net.Mail.MailMessage" /> to include this instance within</param>
        public void Include(MailMessage msg)
        {
            AlternateView altView = AlternateView.CreateAlternateViewFromString(
                this.text,
                System.Text.Encoding.UTF8,
                MediaTypeNames.Text.Html);

            foreach (IEmbeddedResource embeddedRes in this.embeddedResList)
            {
                embeddedRes.Embed(altView);
            }

            msg.AlternateViews.Add(altView);
        }
    }
}
