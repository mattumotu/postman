Imports System.Net.Mail
Imports Postman

'''<summary>
'''This is a test class for PlainEnclosure and is intended to contain all PlainEnclosure Unit Tests
'''</summary>
<TestClass()> _
Public Class PlainEnclosureTest

    '''<summary>
    '''A test for PlainEnclosure Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub PlainEnclosureConstructorTest()
        'Arrange
        Dim expectedAltViewsCount As Integer = 1
        Dim expectedContent As String = "expectedContent"
        Dim expectedEncoding As System.Text.Encoding = System.Text.Encoding.UTF8
        Dim expectedMimeTpye As String = Net.Mime.MediaTypeNames.Text.Plain
        Dim msg As New MailMessage()
        Dim target As IEnclosure = New Enclosure.Plain(expectedContent)

        'Act
        target.Include(msg)

        'Assert
        Assert.AreEqual(expectedAltViewsCount, msg.AlternateViews.Count)
        Assert.AreEqual(expectedContent, New IO.StreamReader(msg.AlternateViews(0).ContentStream).ReadToEnd)
        Assert.AreEqual(expectedEncoding.WebName, msg.AlternateViews(0).ContentType.CharSet)
        Assert.AreEqual(expectedMimeTpye, msg.AlternateViews(0).ContentType.MediaType)
    End Sub

End Class