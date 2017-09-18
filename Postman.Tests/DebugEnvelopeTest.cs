namespace Postman.Tests.Stamp
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Mail;
    using Postman.Stamp;
    using Xunit;

    /// <summary>
    /// This is a test class for DebugEnvelopeTest and is intended
    /// to contain all DebugEnvelope Unit Tests
    /// </summary>
    public class DebugEnvelopeTest
    {
        /// <summary>
        /// A test for DebugEnvelope Rcpt
        /// </summary>
        [Fact]
        public void DebugEnvelope_EncPlain_NewSender()
        {
            // Arrange
            string originalRcpt = "test@test.com";

            ICollection<IStamp> stmps = new List<IStamp>();
            stmps.Add(new Recipient(originalRcpt));

            string expectedContent = "expectedContent";

            ICollection<IEnclosure> encs = new List<IEnclosure>();
            encs.Add(new Enclosure.Plain(expectedContent));

            IEnvelope origin = new Envelope.Envelope(stmps, encs);
            MailAddress expectedRcpt = new MailAddress("newrcpt@test.com");
            IEnvelope target = new Envelope.DebugEnvelope(origin, expectedRcpt.Address);
            MailMessage msg;

            // Act
            msg = target.Unwrap();

            // Assert
            Assert.Equal(1, msg.To.Count);
            Assert.Equal(expectedRcpt, msg.To[0]);
            Assert.Equal(1, msg.AlternateViews.Count);

            string actualContent;
            using (var sr = new StreamReader(msg.AlternateViews[0].ContentStream))
            {
                actualContent = sr.ReadToEnd();
            }

            Assert.True(actualContent.Contains(originalRcpt));
            Assert.True(actualContent.Contains(expectedContent));
        }

        /// <summary>
        /// A test for DebugEnvelope Rcpt
        /// </summary>
        [Fact]
        public void DebugEnvelope_EncPlain_NewSubject()
        {
            // Arrange
            ICollection<IStamp> stmps = new List<IStamp>();
            string originalRcpt = "test@test.com";
            stmps.Add(new Recipient(originalRcpt));
            string originalSubject = "original subject";
            stmps.Add(new Subject(originalSubject));

            ICollection<IEnclosure> encs = new List<IEnclosure>();
            string expectedContent = "expectedContent";
            encs.Add(new Enclosure.Plain(expectedContent));

            IEnvelope origin = new Envelope.Envelope(stmps, encs);
            MailAddress expectedRcpt = new MailAddress("newrcpt@test.com");
            IEnvelope target = new Envelope.DebugEnvelope(origin, expectedRcpt.Address);
            MailMessage msg;

            // Act
            msg = target.Unwrap();

            // Assert
            Assert.Equal(1, msg.AlternateViews.Count);

            string actualContent;
            using (var sr = new StreamReader(msg.AlternateViews[0].ContentStream))
            {
                actualContent = sr.ReadToEnd();
            }

            Assert.True(actualContent.Contains(string.Format("Subject: {0}", originalSubject)));
            Assert.True(actualContent.Contains(expectedContent));
        }
    }
}