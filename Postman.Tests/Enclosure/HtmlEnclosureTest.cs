namespace Postman.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Mail;
    using System.Net.Mime;
    using Xunit;

    /// <summary>
    /// This is a test class for HtmlEnclosure and is intended to contain all HtmlEnclosure and EmbeddedResource Unit Tests
    /// </summary>
    public class HtmlEnclosureTest
    {
        /// <summary>
        /// A test for HtmlEnclosure Constructor
        /// </summary>
        [Fact]
        public void HtmlEnclosureConstructorTest()
        {
            // Arrange
            int expectedAltViewsCount = 1;
            int expectedLinkedResourceCount = 0;
            string expectedContent = "expected<b>Content<b/>";
            System.Text.Encoding expectedEncoding = System.Text.Encoding.UTF8;
            string expectedMimeTpye = MediaTypeNames.Text.Html;
            MailMessage msg = new MailMessage();
            IEnclosure target = new Enclosure.Html(expectedContent);

            // Act
            target.Include(msg);

            // Assert
            Assert.Equal(expectedAltViewsCount, msg.AlternateViews.Count);
            Assert.Equal(expectedContent, new StreamReader(msg.AlternateViews[0].ContentStream).ReadToEnd());
            Assert.Equal(expectedEncoding.WebName, msg.AlternateViews[0].ContentType.CharSet);
            Assert.Equal(expectedMimeTpye, msg.AlternateViews[0].ContentType.MediaType);
            Assert.Equal(expectedLinkedResourceCount, msg.AlternateViews[0].LinkedResources.Count);
        }

        /// <summary>
        /// A test for HtmlEnclosure Constructor
        /// </summary>
        [Fact]
        public void HtmlEnclosureWithEmbeddedResource()
        {
            // Arrange
            int expectedAltViewsCount = 1;
            int expectedLinkedResourceCount = 1;
            string expectedContent = "expected<b>Content<b/>";
            System.Text.Encoding expectedEncoding = System.Text.Encoding.UTF8;
            string expectedMimeTpye = MediaTypeNames.Text.Html;
            string expectedContentId = "expectedContentId";
            ContentType expectedContentType = new ContentType("img/jpeg");
            IEmbeddedResource expectedEmbeddedResource = new EmbeddedResource.EmbeddedResource(new System.IO.MemoryStream(), expectedContentType, expectedContentId);
            ICollection<IEmbeddedResource> resList = new List<IEmbeddedResource>();
            resList.Add(expectedEmbeddedResource);
            MailMessage msg = new MailMessage();
            IEnclosure target = new Enclosure.Html(expectedContent, resList);

            // Act
            target.Include(msg);

            // Assert
            Assert.Equal(expectedAltViewsCount, msg.AlternateViews.Count);
            Assert.Equal(expectedContent, new System.IO.StreamReader(msg.AlternateViews[0].ContentStream).ReadToEnd());
            Assert.Equal(expectedEncoding.WebName, msg.AlternateViews[0].ContentType.CharSet);
            Assert.Equal(expectedMimeTpye, msg.AlternateViews[0].ContentType.MediaType);

            Assert.Equal(expectedLinkedResourceCount, msg.AlternateViews[0].LinkedResources.Count);
            Assert.Equal(expectedContentId, msg.AlternateViews[0].LinkedResources[0].ContentId);
            Assert.Equal(expectedContentType, msg.AlternateViews[0].LinkedResources[0].ContentType);
        }
    }
}