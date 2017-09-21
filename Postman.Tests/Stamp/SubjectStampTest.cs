namespace Postman.Tests
{
    using System.Net.Mail;
    using Postman.Interfaces;
    using Postman.Stamp;
    using Xunit;

    /// <summary>
    /// This is a test class for SubjectStamp and is intended to contain all SubjectStamp Unit Tests
    /// </summary>
    public class SubjectStampTest
    {
        /// <summary>
        /// A test for SubjectStamp Constructor with a string containing a subject
        /// </summary>
        [Fact]
        public void AttachTest()
        {
            // Arrange
            string expectedSubject = "expectedSubject";
            MailMessage msg = new MailMessage();
            IStamp target = new Subject(expectedSubject);

            // Act
            target.Attach(msg);

            // Assert
            Assert.Equal(expectedSubject, msg.Subject);
        }
    }
}