namespace Postman.Tests
{
    using System.Net.Mail;
    using Postman.Interfaces;
    using Xunit;

    /// <summary>
    /// This is a test class for AttachedEnclosure and is intended to contain all AttachedEnclosure Unit Tests
    /// </summary>
    public class AttachedEnclosureTest
    {
        /// <summary>
        /// A test for AttachedEnclosure Constructor
        /// </summary>
        [Fact]
        public void AttachedEnclosureConstructorTest()
        {
            // Arrange
            int expectedAttachementCount = 1;
            Attachment expectedAttachment = new Attachment(new System.IO.MemoryStream(), "Test Attachement");
            MailMessage msg = new MailMessage();
            IEnclosure target = new Enclosure.Attached(expectedAttachment);

            // Act
            target.Include(msg);

            // Assert
            Assert.Equal(expectedAttachementCount, msg.Attachments.Count);
            Assert.Equal(expectedAttachment.Name, msg.Attachments[0].Name);
        }
    }
}