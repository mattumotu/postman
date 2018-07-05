namespace Postman.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Mail;
    using System.Net.Mime;
    using Postman.Interfaces;
    using Xunit;

    /// <summary>
    /// This is a test class for StrictEnvelope and is intended to contain all StrictEnvelope Unit Tests
    /// </summary>
    public class StrictEnvelopeTest
    {
        /// <summary>
        /// Check StrictEnvelope works with all required stamps and enclosures
        /// </summary>
        [Fact]
        public void StrictEnvelope_OK()
        {
            // Arrange
            string expectedRecipient = "recipient@test.com";
            string expectedSender = "sender@test.com";
            string expectedSubject = "original subject";
            string expectedPlainContent = "expected plain content";

            ICollection<IStamp> stmps = new List<IStamp>();
            stmps.Add(new Stamp.Recipient(expectedRecipient));
            stmps.Add(new Stamp.Sender(expectedSender));
            stmps.Add(new Stamp.Subject(expectedSubject));

            ICollection<IEnclosure> encs = new List<IEnclosure>();
            encs.Add(new Enclosure.Plain(expectedPlainContent));

            IEnvelope target = new Envelope.StrictEnvelope(new Envelope.Envelope(stmps, encs));
            MailMessage msg;

            // Act
            msg = target.Unwrap();

            // Assert
            Assert.Equal(1, msg.To.Count);
            Assert.Equal(expectedRecipient, msg.To[0].Address);
            Assert.Equal(expectedSender, msg.From.Address);
            Assert.Contains(expectedSubject, msg.Subject);
            Assert.Equal(1, msg.AlternateViews.Count);

            string actualContent;
            using (var sr = new StreamReader(msg.AlternateViews[0].ContentStream))
            {
                actualContent = sr.ReadToEnd();
            }

            Assert.Contains(expectedPlainContent, actualContent);
        }

        /// <summary>
        /// StrictEnvelope without a recipient throws
        /// </summary>
        [Fact]
        public void StrictEnvelope_NoRecipient_Throws()
        {
            // Arrange
            string expectedSender = "sender@test.com";
            string expectedSubject = "original subject";
            string expectedPlainContent = "expected plain content";

            ICollection<IStamp> stmps = new List<IStamp>();
            stmps.Add(new Stamp.Sender(expectedSender));
            stmps.Add(new Stamp.Subject(expectedSubject));

            ICollection<IEnclosure> encs = new List<IEnclosure>();
            encs.Add(new Enclosure.Plain(expectedPlainContent));

            IEnvelope target = new Envelope.StrictEnvelope(new Envelope.Envelope(stmps, encs));
            MailMessage msg;

            // Act
            System.Exception ex = Assert.Throws<System.InvalidOperationException>(() => msg = target.Unwrap());

            // Assert
            Assert.Equal("list of recipients is empty", ex.Message);
        }

        /// <summary>
        /// StrictEnvelope without a sender throws
        /// </summary>
        [Fact]
        public void StrictEnvelope_NoSender_Throws()
        {
            // Arrange
            string expectedRecipient = "recipient@test.com";
            string expectedSubject = "original subject";
            string expectedPlainContent = "expected plain content";

            ICollection<IStamp> stmps = new List<IStamp>();
            stmps.Add(new Stamp.Recipient(expectedRecipient));
            stmps.Add(new Stamp.Subject(expectedSubject));

            ICollection<IEnclosure> encs = new List<IEnclosure>();
            encs.Add(new Enclosure.Plain(expectedPlainContent));

            IEnvelope target = new Envelope.StrictEnvelope(new Envelope.Envelope(stmps, encs));
            MailMessage msg;

            // Act
            System.Exception ex = Assert.Throws<System.InvalidOperationException>(() => msg = target.Unwrap());

            // Assert
            Assert.Equal("sender is Nothing", ex.Message);
        }

        /// <summary>
        /// StrictEnvelope without a subject throws
        /// </summary>
        [Fact]
        public void StrictEnvelope_NoSubject_Throws()
        {
            // Arrange
            string expectedRecipient = "recipient@test.com";
            string expectedSender = "sender@test.com";
            string expectedPlainContent = "expected plain content";

            ICollection<IStamp> stmps = new List<IStamp>();
            stmps.Add(new Stamp.Recipient(expectedRecipient));
            stmps.Add(new Stamp.Sender(expectedSender));

            ICollection<IEnclosure> encs = new List<IEnclosure>();
            encs.Add(new Enclosure.Plain(expectedPlainContent));

            IEnvelope target = new Envelope.StrictEnvelope(new Envelope.Envelope(stmps, encs));
            MailMessage msg;

            // Act
            System.Exception ex = Assert.Throws<System.InvalidOperationException>(() => msg = target.Unwrap());

            // Assert
            Assert.Equal("subject is Nothing or empty", ex.Message);
        }

        //TODO: Test missing enclosures throws
    }
}
