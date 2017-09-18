namespace Postman.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Mail;
    using System.Net.Mime;
    using Postman.Stamp;
    using Xunit;

    /// <summary>
    /// This is a test class for DebugEnvelopeTest and is intended
    /// to contain all DebugEnvelope Unit Tests
    /// </summary>
    public class DebugEnvelopeTest
    {
        /// <summary>
        /// A test for DebugEnvelope Rcpt with a Plain encolsure
        /// </summary>
        [Fact]
        public void DebugEnvelope_EncPlain()
        {
            // Arrange
            string originalRcpt = "test@test.com";
            string originalSubject = "original subject";
            string expectedContent = "expectedContent";

            ICollection<IStamp> stmps = new List<IStamp>();
            stmps.Add(new Recipient(originalRcpt));
            stmps.Add(new Subject(originalSubject));

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
            Assert.Contains(originalSubject, msg.Subject);
            Assert.Equal(1, msg.AlternateViews.Count);

            string actualContent;
            using (var sr = new StreamReader(msg.AlternateViews[0].ContentStream))
            {
                actualContent = sr.ReadToEnd();
            }

            Assert.Contains(originalRcpt, actualContent);
            Assert.Contains(originalSubject, actualContent);
            Assert.Contains(expectedContent, actualContent);
        }

        /// <summary>
        /// A test for DebugEnvelope Rcpt with a HTML encolsure and embedded resource
        /// </summary>
        [Fact]
        public void DebugEnvelope_HtmlPlain()
        {
            // Arrange
            string originalRcpt = "test@test.com";
            string originalSubject = "original subject";
            string expectedContent = "<p>expectedContent</p>";

            ICollection<IStamp> stmps = new List<IStamp>();
            stmps.Add(new Recipient(originalRcpt));
            stmps.Add(new Subject(originalSubject));

            string expectedContentId = "expectedContentId";
            ContentType expectedContentType = new ContentType("img/jpeg");
            IEmbeddedResource expectedEmbeddedResource = new EmbeddedResource.EmbeddedResource(new System.IO.MemoryStream(), expectedContentType, expectedContentId);
            ICollection<IEmbeddedResource> resList = new List<IEmbeddedResource>();
            resList.Add(expectedEmbeddedResource);

            ICollection<IEnclosure> encs = new List<IEnclosure>();
            encs.Add(new Enclosure.Html(expectedContent, resList));

            IEnvelope origin = new Envelope.Envelope(stmps, encs);
            MailAddress expectedRcpt = new MailAddress("newrcpt@test.com");
            IEnvelope target = new Envelope.DebugEnvelope(origin, expectedRcpt.Address);
            MailMessage msg;

            // Act
            msg = target.Unwrap();

            // Assert
            Assert.Equal(1, msg.To.Count);
            Assert.Equal(expectedRcpt, msg.To[0]);
            Assert.Contains(originalSubject, msg.Subject);
            Assert.Equal(1, msg.AlternateViews.Count);

            string actualContent;
            using (var sr = new StreamReader(msg.AlternateViews[0].ContentStream))
            {
                actualContent = sr.ReadToEnd();
            }

            Assert.Contains(originalRcpt, actualContent);
            Assert.Contains(originalSubject, actualContent);
            Assert.Contains(expectedContent, actualContent);

            Assert.Equal(1, msg.AlternateViews[0].LinkedResources.Count);
            Assert.Equal(expectedContentId, msg.AlternateViews[0].LinkedResources[0].ContentId);
            Assert.Equal(expectedContentType, msg.AlternateViews[0].LinkedResources[0].ContentType);
        }

        /// <summary>
        /// A test for DebugEnvelope Rcpt with a CC stamp & plain Env
        /// </summary>
        [Fact]
        public void DebugEnvelope_StampCC_EncPlain()
        {
            // Arrange
            string originalRcpt = "test@test.com";
            string originalCC = "cc@test.com";
            string originalSubject = "original subject";
            string expectedContent = "expectedContent";

            ICollection<IStamp> stmps = new List<IStamp>();
            stmps.Add(new Recipient(originalRcpt));
            stmps.Add(new Cc(originalCC));
            stmps.Add(new Subject(originalSubject));

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
            Assert.Contains(originalSubject, msg.Subject);
            Assert.Equal(0, msg.CC.Count);
            Assert.Equal(1, msg.AlternateViews.Count);

            string actualContent;
            using (var sr = new StreamReader(msg.AlternateViews[0].ContentStream))
            {
                actualContent = sr.ReadToEnd();
            }

            Assert.Contains(originalRcpt, actualContent);
            Assert.Contains(originalCC, actualContent);
            Assert.Contains(originalSubject, actualContent);
            Assert.Contains(expectedContent, actualContent);
        }

        /// <summary>
        /// A test for DebugEnvelope Rcpt with a BCC stamp & plain Env
        /// </summary>
        [Fact]
        public void DebugEnvelope_StampBCC_EncPlain()
        {
            // Arrange
            string originalRcpt = "test@test.com";
            string originalBCC = "bcc@test.com";
            string originalSubject = "original subject";
            string expectedContent = "expectedContent";

            ICollection<IStamp> stmps = new List<IStamp>();
            stmps.Add(new Recipient(originalRcpt));
            stmps.Add(new Bcc(originalBCC));
            stmps.Add(new Subject(originalSubject));

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
            Assert.Contains(originalSubject, msg.Subject);
            Assert.Equal(0, msg.Bcc.Count);
            Assert.Equal(1, msg.AlternateViews.Count);

            string actualContent;
            using (var sr = new StreamReader(msg.AlternateViews[0].ContentStream))
            {
                actualContent = sr.ReadToEnd();
            }

            Assert.Contains(originalRcpt, actualContent);
            Assert.Contains(originalBCC, actualContent);
            Assert.Contains(originalSubject, actualContent);
            Assert.Contains(expectedContent, actualContent);
        }

        //TODO: Test attachments
    }
}