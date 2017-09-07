namespace Postman.Envelope
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Mail;
    using System.Net.Mime;

    /// <summary>
    /// Accepts an IEnvelope replacing recipient and dropping cc and bcc stamps
    /// </summary>
    public class DebugEnvelope : IEnvelope
    {
        private IEnvelope origin;
        private string recipient;

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugEnvelope" /> class with the specified <see cref="IEnvelope"/> origin and recipient.
        /// </summary>
        /// <param name="origin">the origin envelope</param>
        /// <param name="rcpt">the new recipient</param>
        public DebugEnvelope(IEnvelope origin, string rcpt)
        {
            this.origin = origin;
            this.recipient = rcpt;
        }

        /// <summary>
        /// Unwrap this instance into a <see cref="System.Net.Mail.MailMessage" />
        /// </summary>
        /// <returns>a populated <see cref="System.Net.Mail.MailMessage" /></returns>
        public MailMessage Unwrap()
        {
            MailMessage msg = this.origin.Unwrap();

            string debugHtml = "<b>Previous Stamps:</b><br />";
            string debugPlain = "Previous Stamps:" + Environment.NewLine;

            foreach (MailAddress rcpt in msg.To)
            {
                debugHtml += string.Format("To: <i>{0} &lt;{1}&gt;</i><br />", rcpt.DisplayName, rcpt.Address);
                debugPlain += string.Format("To: {0} &lt;{1}&gt;", rcpt.DisplayName, rcpt.Address) + Environment.NewLine;
            }

            List<IStamp> stampList = new List<IStamp>();

            stampList.Add(new Stamp.Recipient(this.recipient));
            msg.To.Clear();

            foreach (MailAddress cc in msg.CC)
            {
                debugHtml += string.Format("CC: <i>{0} &lt;{1}&gt;</i><br />", cc.DisplayName, cc.Address);
                debugPlain += string.Format("CC: {0} &lt;{1}&gt;", cc.DisplayName, cc.Address) + Environment.NewLine;
            }

            msg.CC.Clear();

            foreach (MailAddress bcc in msg.Bcc)
            {
                debugHtml += string.Format("BCC: <i>{0} &lt;{1}&gt;</i><br />", bcc.DisplayName, bcc.Address);
                debugPlain += string.Format("BCC: {0} &lt;{1}&gt;", bcc.DisplayName, bcc.Address) + Environment.NewLine;
            }

            msg.Bcc.Clear();

            debugHtml += string.Format("Subject: <i>{0}</i><br />", msg.Subject);
            debugPlain += string.Format("Subject: {0}", msg.Subject) + Environment.NewLine;

            stampList.Add(new Stamp.Subject(string.Format("DEBUG: {0}", msg.Subject)));

            foreach (IStamp stmp in stampList)
            {
                stmp.Attach(msg);
            }

            debugHtml += "<br />Original Body follows:<br /><hr />";
            debugPlain += Environment.NewLine + "Original Body follows:";

            List<IEnclosure> encList = new List<IEnclosure>();

            foreach (AlternateView altView in msg.AlternateViews)
            {
                switch (altView.ContentType.MediaType)
                {
                    case MediaTypeNames.Text.Html:
                        using (StreamReader sr = new StreamReader(altView.ContentStream))
                        {
                            debugHtml += "<br />" + sr.ReadToEnd();
                        }

                        List<IEmbeddedResource> embResList = new List<IEmbeddedResource>();
                        foreach (LinkedResource lnkRes in altView.LinkedResources)
                        {
                            embResList.Add(new EmbeddedResource.EmbeddedResource(lnkRes.ContentStream, lnkRes.ContentType, lnkRes.ContentId));
                        }

                        encList.Add(new Enclosure.Html(debugHtml, embResList));
                        break;

                    case MediaTypeNames.Text.Plain:
                        using (StreamReader sr = new StreamReader(altView.ContentStream))
                        {
                            debugPlain += Environment.NewLine + sr.ReadToEnd();
                        }
                        encList.Add(new Enclosure.Plain(debugPlain));
                        break;
                }
            }

            msg.AlternateViews.Clear();

            foreach (IEnclosure enc in encList)
            {
                enc.Include(msg);
            }

            return msg;
        }
    }
}