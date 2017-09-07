Imports System.Net.Mail
Imports Postman

''' <summary>
''' This is a test class for SubjectStamp and is intended to contain all SubjectStamp Unit Tests
''' </summary>
<TestClass()> _
Public Class SubjectStampTest

    '''<summary>
    '''A test for SubjectStamp Constructor with a string containing a subject
    '''</summary>
    <TestMethod()> _
    Public Sub AttachTest()
        'Arrange
        Dim expectedSubject As String = "expectedSubject"
        Dim msg As New MailMessage()
        Dim target As IStamp = New Stamp.Subject(expectedSubject)

        'Act
        target.Attach(msg)

        'Assert
        Assert.AreEqual(expectedSubject, msg.Subject)
    End Sub

End Class