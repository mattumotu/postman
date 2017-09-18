namespace Postman.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Mail;
    using System.Net.Mime;
    using Xunit;

    /// <summary>
    /// This is a test class for StrictEnvelope and is intended to contain all StrictEnvelope Unit Tests
    /// </summary>
    public class StrictEnvelopeTest
    {
        //TODO: Test all ok
        //TODO: Test missing To throws
        //TODO: Test missing From throws
        //TODO: Test missing Subject throws
        //TODO: Test missing enclosures throws

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

            IEnvelope target = new Envelope.Envelope(stmps, encs);
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
    }
}
