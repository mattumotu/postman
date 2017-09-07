Imports System.Net.Mail
Imports Postman

'''<summary>
'''This is a test class for AttachedEnclosure and is intended to contain all AttachedEnclosure Unit Tests
'''</summary>
<TestClass()> _
Public Class AttachedEnclosureTest

    '''<summary>
    '''A test for AttachedEnclosure Constructor
    '''</summary>
    <TestMethod()> _
    Public Sub AttachedEnclosureConstructorTest()
        'Arrange
        Dim expectedAttachementCount As Integer = 1
        Dim expectedAttachment As New Attachment(New System.IO.MemoryStream(), "Test Attachement")
        Dim msg As New MailMessage()
        Dim target As IEnclosure = New Enclosure.Attached(expectedAttachment)

        'Act
        target.Include(msg)

        'Assert
        Assert.AreEqual(expectedAttachementCount, msg.Attachments.Count)
        Assert.AreEqual(expectedAttachment.Name, msg.Attachments(0).Name)
    End Sub

End Class