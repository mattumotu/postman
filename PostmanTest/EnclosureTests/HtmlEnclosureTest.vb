Imports System.Net.Mail
Imports Postman

'''<summary>
'''This is a test class for HtmlEnclosure and is intended to contain all HtmlEnclosure and EmbeddedResource Unit Tests
'''</summary>
<TestClass()> _
Public Class HtmlEnclosureTest

    '''<summary>
    '''A test for HtmlEnclosure Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub HtmlEnclosureConstructorTest()
        'Arrange
        Dim expectedAltViewsCount As Integer = 1
        Dim expectedLinkedResourceCount As Integer = 0
        Dim expectedContent As String = "expected<b>Content<b/>"
        Dim expectedEncoding As System.Text.Encoding = System.Text.Encoding.UTF8
        Dim expectedMimeTpye As String = Net.Mime.MediaTypeNames.Text.Html
        Dim msg As New MailMessage()
        Dim target As IEnclosure = New Enclosure.Html(expectedContent)

        'Act
        target.Include(msg)

        'Assert
        Assert.AreEqual(expectedAltViewsCount, msg.AlternateViews.Count)
        Assert.AreEqual(expectedContent, New IO.StreamReader(msg.AlternateViews(0).ContentStream).ReadToEnd)
        Assert.AreEqual(expectedEncoding.WebName, msg.AlternateViews(0).ContentType.CharSet)
        Assert.AreEqual(expectedMimeTpye, msg.AlternateViews(0).ContentType.MediaType)
        Assert.AreEqual(expectedLinkedResourceCount, msg.AlternateViews(0).LinkedResources.Count)
    End Sub

    '''<summary>
    '''A test for HtmlEnclosure Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub HtmlEnclosureConstructorTest1()
        'Arrange
        Dim expectedAltViewsCount As Integer = 1
        Dim expectedLinkedResourceCount As Integer = 1
        Dim expectedContent As String = "expected<b>Content<b/>"
        Dim expectedEncoding As System.Text.Encoding = System.Text.Encoding.UTF8
        Dim expectedMimeTpye As String = Net.Mime.MediaTypeNames.Text.Html
        Dim expectedContentId As String = "expectedContentId"
        Dim expectedContentType As New Net.Mime.ContentType("img/jpeg")
        Dim expectedEmbeddedResource As IEmbeddedResource = New EmbeddedResource.EmbeddedResource(New System.IO.MemoryStream(), expectedContentType, expectedContentId)
        Dim resList As New List(Of IEmbeddedResource)
        resList.Add(expectedEmbeddedResource)
        Dim msg As New MailMessage()
        Dim target As IEnclosure = New Enclosure.Html(expectedContent, resList)

        'Act
        target.Include(msg)

        'Assert
        Assert.AreEqual(expectedAltViewsCount, msg.AlternateViews.Count)
        Assert.AreEqual(expectedContent, New IO.StreamReader(msg.AlternateViews(0).ContentStream).ReadToEnd)
        Assert.AreEqual(expectedEncoding.WebName, msg.AlternateViews(0).ContentType.CharSet)
        Assert.AreEqual(expectedMimeTpye, msg.AlternateViews(0).ContentType.MediaType)

        Assert.AreEqual(expectedLinkedResourceCount, msg.AlternateViews(0).LinkedResources.Count)
        Assert.AreEqual(expectedContentId, msg.AlternateViews(0).LinkedResources(0).ContentId)
        Assert.AreEqual(expectedContentType, msg.AlternateViews(0).LinkedResources(0).ContentType)
    End Sub

End Class