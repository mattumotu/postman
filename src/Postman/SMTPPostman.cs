namespace Postman
{
    using System.Collections.Generic;
    using System.Net.Mail;
    using Postman.Interfaces;

    /// <summary>
    /// An <see cref="SMTPPostman"/> sends a <see cref="IEnvelope"/> via an SMTP server
    /// </summary>
    public class SMTPPostman : IPostman
    {
        /// <summary>
        /// Holds the SMTP host
        /// </summary>
        private readonly string host;

        /// <summary>
        /// Initializes a new instance of the <see cref="SMTPPostman" /> class with the specified SMTP host.
        /// </summary>
        /// <param name="smtpHost">A string that contains an SMPT host</param>
        /// <example>
        /// This example shows basic C# use of Postman
        /// <code>
        /// using System.Collections.Generic;
        /// using Postman
        /// using Postman.Interfaces
        ///
        /// // Create Envelope
        /// ICollection<IStamp> stamps = new List<IStamp>();
        /// stamps.Add(new Stamp.Recipient("test@test.com; test1@test.com"));
        /// stamps.Add(new Stamp.Subject("This is a test email"));
        /// stamps.Add(new Stamp.Sender("test@test.com", "test account"));
        ///
        /// ICollection<IEnclosure> enclosures = new List<IEnclosure>();
        /// enclosures.Add(new Enclosure.Plain("plain text"));
        ///
        /// IEnvelope exampleEnv = new Envelope(stamps, enclosures);
        ///
        /// // Create EmailPostman
        /// IPostman postman = new SMTPPostman("my.smtp.host");
        /// // Send Envelope
        /// postman.Send(exampleEnv);
        /// </code>
        /// </example>
        /// <example>
        /// This example shows basic VB.net use of SMTPPostman
        /// <code>
        /// Imports System.Collections.Generic
        /// Imports Postman
        /// Imports Postman.Interfaces
        ///
        /// ' Create Envelope '
        /// Dim stamps As ICollection(Of IStamp) = New List(Of IStamp)()
        /// stamps.Add(New Stamp.Recipient("test@test.com; test1@test.com"))
        /// stamps.Add(New Stamp.Subject("This is a test email"))
        /// stamps.Add(New Stamp.Sender("test@test.com", "test account"))
        ///
        /// Dim enclosures As ICollection(Of IEnclosure) = New List(Of IEnclosure)()
        /// enclosures.Add(New Enclosure.Plain("plain text"))
        ///
        /// Dim embResList As New List(Of IEmbeddedResource)
        /// embResList.Add(New EmbeddedResource.EmbeddedResource(
        ///                 HttpContext.Current.Server.MapPath("~/Images/ExmapleImage.jpg"),
        ///                 New Net.Mime.ContentType(Net.Mime.MediaTypeNames.Image.Jpeg),
        ///                 "APHALogo"))
        /// encs.Add(New Enclosure.Html("My <b>HTML</b> Text <img src=cid:APHALogo>", embResList))
        ///
        /// Dim exampleEnv As IEnvelope = New Envelope(stamps, enclosures)
        ///
        /// ' Create EmailPostman '
        /// Dim postman As IPostman = New SMTPPostman("my.smtp.host")
        /// ' Send Envelope '
        /// postman.Send(exampleEnv)
        /// </code>
        /// </example>
        public SMTPPostman(string smtpHost)
        {
            this.host = smtpHost;
        }

        /// <summary>
        /// Sends the specified <see cref="IEnvelope"/> via SMTP
        /// </summary>
        /// <param name="env">the <see cref="IEnvelope"/> to be sent</param>
        public void Send(IEnvelope env)
        {
            SmtpClient smtp = new SmtpClient(this.host);
            smtp.Send(env.Unwrap());
            smtp.Dispose();
        }
    }
}