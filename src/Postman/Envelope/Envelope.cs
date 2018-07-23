namespace Postman.Envelope
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mail;
    using Postman.Interfaces;

    /// <summary>
    /// Represents an email.
    /// </summary>
    public class Envelope : IEnvelope
    {
        /// <summary>
        /// Holds the stamps
        /// </summary>
        private readonly IEnumerable<IStamp> stamps;

        /// <summary>
        /// Holds the enclosures
        /// </summary>
        private readonly IEnumerable<IEnclosure> enclosures;

        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope" /> class with the specified <see cref="IStamp"/>s and <see cref="IEnclosure"/>s.
        /// </summary>
        /// <param name="stmps">a list of required IStamps</param>
        /// <param name="encs">a list of required IEnclosures</param>
        public Envelope(IEnumerable<IStamp> stmps, IEnumerable<IEnclosure> encs)
        {
            this.stamps = stmps;
            this.enclosures = encs;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope" /> class with the specified <see cref="IStamp"/>s.
        /// </summary>
        /// <param name="stmps">a list of required IStamps</param>
        public Envelope(IEnumerable<IStamp> stmps)
            : this(stmps, Enumerable.Empty<IEnclosure>())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope" /> class with the specified <see cref="IEnclosure"/>s.
        /// </summary>
        /// <param name="encs">a list of required IEnclosures</param>
        public Envelope(IEnumerable<IEnclosure> encs)
            : this(Enumerable.Empty<IStamp>(), encs)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Envelope" /> class.
        /// </summary>
        public Envelope()
            : this(Enumerable.Empty<IStamp>(), Enumerable.Empty<IEnclosure>())
        { }

        /// <summary>
        /// Unwrap this instance into a <see cref="System.Net.Mail.MailMessage" />
        /// </summary>
        /// <returns>a populated <see cref="System.Net.Mail.MailMessage" /></returns>
        public MailMessage Unwrap()
        {
            MailMessage msg = new MailMessage();

            foreach (IStamp stamp in this.stamps)
            {
                stamp.Attach(msg);
            }

            foreach (IEnclosure enclosure in this.enclosures)
            {
                enclosure.Include(msg);
            }

            return msg;
        }
    }
}
