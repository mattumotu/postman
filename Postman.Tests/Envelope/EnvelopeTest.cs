namespace Postman.Tests.Stamp
{
    using System.Collections.Generic;
    using System.Net.Mail;
    using Postman.Stamp;
    using Xunit;

    /// <summary>
    /// This is a test class for MIMEEnvelopeTest and is intended
    /// to contain all MIMEEnvelopeTest Unit Tests
    /// </summary>
    public class EnvelopeTest
    {
        /// <summary>
        /// A test for MIMEEnvelope Constructor
        /// </summary>
        [Fact]
        public void MIMEEnvelope_NoStamps_NoEnclosures()
        {
            // Arrange
            IEnvelope target = new Envelope.Envelope();
            MailMessage msg;

            // Act
            msg = target.Unwrap();

            // Assert
            Assert.Equal(null, msg.Sender);
            Assert.Equal(0, msg.To.Count);
            Assert.Equal(0, msg.CC.Count);
            Assert.Equal(0, msg.Bcc.Count);
            Assert.Equal(string.Empty, msg.Subject);
            Assert.Equal(0, msg.AlternateViews.Count);
        }

        /// <summary>
        /// A test for MIMEEnvelope Constructor
        /// </summary>
        [Fact]
        public void MIMEEnvelope_OneStamp_NoEnclosures()
        {
            // Arrange

            ICollection<IStamp> stmps = new List<IStamp>();
            string expectedSubject = "expectedSubject";
            stmps.Add(new Subject(expectedSubject));
            IEnvelope target = new Envelope.Envelope(stmps);
            MailMessage msg;

            // Act
            msg = target.Unwrap();

            // Assert
            Assert.Equal(null, msg.Sender);
            Assert.Equal(0, msg.To.Count);
            Assert.Equal(0, msg.CC.Count);
            Assert.Equal(0, msg.Bcc.Count);
            Assert.Equal(expectedSubject, msg.Subject);
            Assert.Equal(0, msg.AlternateViews.Count);
        }

        /// <summary>
        /// A test for MIMEEnvelope Constructor
        /// </summary>
        [Fact]
        public void MIMEEnvelope_NoStamps_OneEnclosures()
        {
            // Arrange
            ICollection<IEnclosure> encs = new List<IEnclosure>();
            string expectedContent = "expectedContent";
            encs.Add(new Enclosure.Plain(expectedContent));
            IEnvelope target = new Envelope.Envelope(encs);
            MailMessage msg;

            // Act
            msg = target.Unwrap();

            // Assert
            Assert.Equal(null, msg.Sender);
            Assert.Equal(0, msg.To.Count);
            Assert.Equal(0, msg.CC.Count);
            Assert.Equal(0, msg.Bcc.Count);
            Assert.Equal(string.Empty, msg.Subject);
            Assert.Equal(1, msg.AlternateViews.Count);
        }

        /// <summary>
        /// A test for MIMEEnvelope Constructor
        /// </summary>
        [Fact]
        public void MIMEEnvelope_MultiStamps_MultiEnclosures()
        {
            // Arrange
            ICollection<IStamp> stmps = new List<IStamp>();
            string expectedSubject = "expectedSubject";
            string expectedSender = "test123@test.com";
            stmps.Add(new Subject(expectedSubject));
            stmps.Add(new Sender(expectedSender));
            ICollection<IEnclosure> encs = new List<IEnclosure>();
            string expectedContent = "expectedContent";
            encs.Add(new Enclosure.Plain(expectedContent));
            encs.Add(new Enclosure.Plain(expectedContent));
            IEnvelope target = new Envelope.Envelope(stmps, encs);
            MailMessage msg;

            // Act
            msg = target.Unwrap();

            // Assert
            Assert.Equal(expectedSender, msg.Sender.Address);
            Assert.Equal(0, msg.To.Count);
            Assert.Equal(0, msg.CC.Count);
            Assert.Equal(0, msg.Bcc.Count);
            Assert.Equal(expectedSubject, msg.Subject);
            Assert.Equal(2, msg.AlternateViews.Count);
        }
    }
}