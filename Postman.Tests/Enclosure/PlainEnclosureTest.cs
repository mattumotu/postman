namespace Postman.Tests.Stamp
{
    using System.IO;
    using System.Net.Mail;
    using System.Net.Mime;
    using Xunit;

    /// <summary>
    /// This is a test class for PlainEnclosure and is intended to contain all PlainEnclosure Unit Tests
    /// </summary>
    public class PlainEnclosureTest
    {
        /// <summary>
        /// A test for PlainEnclosure Constructor
        /// </summary>
        [Fact]
        public void PlainEnclosureConstructorTest()
        {
            // Arrange
            int expectedAltViewsCount = 1;
            string expectedContent = "expectedContent";
            System.Text.Encoding expectedEncoding = System.Text.Encoding.UTF8;
            string expectedMimeTpye = MediaTypeNames.Text.Plain;
            MailMessage msg = new MailMessage();
            IEnclosure target = new Enclosure.Plain(expectedContent);

            // Act
            target.Include(msg);

            // Assert
            Assert.Equal(expectedAltViewsCount, msg.AlternateViews.Count);
            Assert.Equal(expectedContent, new StreamReader(msg.AlternateViews[0].ContentStream).ReadToEnd());
            Assert.Equal(expectedEncoding.WebName, msg.AlternateViews[0].ContentType.CharSet);
            Assert.Equal(expectedMimeTpye, msg.AlternateViews[0].ContentType.MediaType);
        }
    }
}