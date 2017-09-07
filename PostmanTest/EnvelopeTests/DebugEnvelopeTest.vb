Imports System.Net.Mail
Imports Postman
Imports System.IO

'''<summary>
'''This is a test class for DebugEnvelopeTest and is intended
'''to contain all DebugEnvelope Unit Tests
'''</summary>
<TestClass()>
Public Class DebugEnvelopeTest

    '''<summary>
    '''A test for DebugEnvelope Rcpt
    '''</summary>
    <TestMethod()> _
    Public Sub DebugEnvelope_NewSender()
        'Arrange
        Dim stmps As New List(Of IStamp)
        Dim originalRcpt As String = "test@test.com"
        stmps.Add(New Stamp.Recipient(originalRcpt))

        Dim encs As New List(Of IEnclosure)
        Dim expectedContent As String = "expectedContent"
        encs.Add(New Enclosure.Plain(expectedContent))

        Dim origin As IEnvelope = New Envelope.Envelope(stmps, encs)
        Dim expectedRcpt As MailAddress = New MailAddress("newrcpt@test.com")
        Dim target As IEnvelope = New Envelope.DebugEnvelope(origin, expectedRcpt.Address)
        Dim msg As MailMessage

        'Act
        msg = target.Unwrap()

        'Assert
        Assert.AreEqual(1, msg.To.Count)
        Assert.AreEqual(expectedRcpt, msg.To.Item(0))
        Assert.AreEqual(1, msg.AlternateViews.Count)

        Dim actualContent As String
        Using sr = New StreamReader(msg.AlternateViews.Item(0).ContentStream)
            actualContent = sr.ReadToEnd()
        End Using

        Assert.IsTrue(actualContent.Contains(originalRcpt))
        Assert.IsTrue(actualContent.Contains(expectedContent))
    End Sub

    '''<summary>
    '''A test for DebugEnvelope Rcpt
    '''</summary>
    <TestMethod()> _
    Public Sub DebugEnvelope_NewSubject()
        'Arrange
        Dim stmps As New List(Of IStamp)
        Dim originalRcpt As String = "test@test.com"
        stmps.Add(New Stamp.Recipient(originalRcpt))
        Dim originalSubject As String = "original subject"
        stmps.Add(New Stamp.Subject(originalSubject))

        Dim encs As New List(Of IEnclosure)
        Dim expectedContent As String = "expectedContent"
        encs.Add(New Enclosure.Plain(expectedContent))

        Dim origin As IEnvelope = New Envelope.Envelope(stmps, encs)
        Dim expectedRcpt As MailAddress = New MailAddress("newrcpt@test.com")
        Dim target As IEnvelope = New Envelope.DebugEnvelope(origin, expectedRcpt.Address)
        Dim msg As MailMessage

        'Act
        msg = target.Unwrap()

        'Assert
        Assert.AreEqual(1, msg.AlternateViews.Count)

        Dim actualContent As String
        Using sr = New StreamReader(msg.AlternateViews.Item(0).ContentStream)
            actualContent = sr.ReadToEnd()
        End Using

        Assert.IsTrue(actualContent.Contains(String.Format("Subject: {0}", originalSubject)))
        Assert.IsTrue(actualContent.Contains(expectedContent))
    End Sub

End Class
