Imports System.Net.Mail
Imports Postman

'''<summary>
'''This is a test class for MIMEEnvelopeTest and is intended
'''to contain all MIMEEnvelopeTest Unit Tests
'''</summary>
<TestClass()> _
Public Class EnvelopeTest

    '''<summary>
    '''A test for MIMEEnvelope Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub MIMEEnvelope_NoStamps_NoEnclosures()
        'Arrange
        Dim stmps As New List(Of IStamp)
        Dim encs As New List(Of IEnclosure)
        Dim target As IEnvelope = New Envelope.Envelope(stmps, encs)
        Dim msg As MailMessage

        'Act
        msg = target.Unwrap()

        'Assert
        Assert.AreEqual(Nothing, msg.Sender)
        Assert.AreEqual(0, msg.To.Count)
        Assert.AreEqual(0, msg.CC.Count)
        Assert.AreEqual(0, msg.Bcc.Count)
        Assert.AreEqual(String.Empty, msg.Subject)
        Assert.AreEqual(0, msg.AlternateViews.Count)
    End Sub

    '''<summary>
    '''A test for MIMEEnvelope Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub MIMEEnvelope_OneStamp_NoEnclosures()
        'Arrange
        Dim stmps As New List(Of IStamp)
        Dim expectedSubject As String = "expectedSubject"
        stmps.Add(New Stamp.Subject(expectedSubject))
        Dim encs As New List(Of IEnclosure)
        Dim target As IEnvelope = New Envelope.Envelope(stmps, encs)
        Dim msg As MailMessage

        'Act
        msg = target.Unwrap()

        'Assert
        Assert.AreEqual(Nothing, msg.Sender)
        Assert.AreEqual(0, msg.To.Count)
        Assert.AreEqual(0, msg.CC.Count)
        Assert.AreEqual(0, msg.Bcc.Count)
        Assert.AreEqual(expectedSubject, msg.Subject)
        Assert.AreEqual(0, msg.AlternateViews.Count)
    End Sub

    '''<summary>
    '''A test for MIMEEnvelope Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub MIMEEnvelope_NoStamps_OneEnclosures()
        'Arrange
        Dim stmps As New List(Of IStamp)
        Dim encs As New List(Of IEnclosure)
        Dim expectedContent As String = "expectedContent"
        encs.Add(New Enclosure.Plain(expectedContent))
        Dim target As IEnvelope = New Envelope.Envelope(stmps, encs)
        Dim msg As MailMessage

        'Act
        msg = target.Unwrap()

        'Assert
        Assert.AreEqual(Nothing, msg.Sender)
        Assert.AreEqual(0, msg.To.Count)
        Assert.AreEqual(0, msg.CC.Count)
        Assert.AreEqual(0, msg.Bcc.Count)
        Assert.AreEqual(String.Empty, msg.Subject)
        Assert.AreEqual(1, msg.AlternateViews.Count)
    End Sub

    '''<summary>
    '''A test for MIMEEnvelope Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub MIMEEnvelope_MultiStamps_MultiEnclosures()
        'Arrange
        Dim stmps As New List(Of IStamp)
        Dim expectedSubject As String = "expectedSubject"
        Dim expectedSender As String = "test123@test.com"
        stmps.Add(New Stamp.Subject(expectedSubject))
        stmps.Add(New Stamp.Sender(expectedSender))
        Dim encs As New List(Of IEnclosure)
        Dim expectedContent As String = "expectedContent"
        encs.Add(New Enclosure.Plain(expectedContent))
        encs.Add(New Enclosure.Plain(expectedContent))
        Dim target As IEnvelope = New Envelope.Envelope(stmps, encs)
        Dim msg As MailMessage

        'Act
        msg = target.Unwrap()

        'Assert
        Assert.AreEqual(expectedSender, msg.Sender.Address)
        Assert.AreEqual(0, msg.To.Count)
        Assert.AreEqual(0, msg.CC.Count)
        Assert.AreEqual(0, msg.Bcc.Count)
        Assert.AreEqual(expectedSubject, msg.Subject)
        Assert.AreEqual(2, msg.AlternateViews.Count)
    End Sub

End Class