Imports System.Net.Mail
Imports Postman

'''<summary>
''' This is a test class for SenderStamp and is intended to contain all SenderStamp Unit Tests
'''</summary>
<TestClass()> _
Public Class SenderStampTest

    '''<summary>
    '''A test for SenderStamp Constructor with a string containing a single email addresses
    '''</summary>
    <TestMethod()> _
    Public Sub AddressString()
        'Arrange
        Dim expectedAddr As String = "test@test.com"
        Dim msg As New MailMessage()
        Dim target As IStamp = New Stamp.Sender(expectedAddr)

        'Act
        target.Attach(msg)

        'Assert
        Assert.AreEqual(expectedAddr, msg.Sender.Address)
    End Sub

    '''<summary>
    '''A test for SenderStamp Constructor with a string email address and string display name
    '''</summary>
    <TestMethod()> _
    Public Sub AddressStringAndDisplayNameString()
        'Arrange
        Dim expectedAddr As String = "test@test.com"
        Dim expectedDispName As String = "test user"
        Dim msg As New MailMessage()
        Dim target As IStamp = New Stamp.Sender(expectedAddr, expectedDispName)

        'Act
        target.Attach(msg)

        'Assert
        Assert.AreEqual(expectedAddr, msg.Sender.Address)
        Assert.AreEqual(expectedDispName, msg.Sender.DisplayName)
    End Sub

    '''<summary>
    '''A test for SenderStamp Constructor with a MailAddress
    '''</summary>
    <TestMethod()> _
    Public Sub MailAddress()
        'Arrange
        Dim expectedAddr As New MailAddress("test@test.com", "test user")
        Dim msg As New MailMessage()
        Dim target As IStamp = New Stamp.Sender(expectedAddr)

        'Act
        target.Attach(msg)

        'Assert
        Assert.AreEqual(expectedAddr, msg.Sender)
        Assert.AreEqual(expectedAddr.Address, msg.Sender.Address)
        Assert.AreEqual(expectedAddr.DisplayName, msg.Sender.DisplayName)
    End Sub

    ''' <summary>
    ''' A test for SenderStamp Contructor with multiple addresses
    ''' </summary>
    <TestMethod()> _
    <ExpectedException(GetType(System.FormatException))> _
    Public Sub MultipleSendersThrowsException()
        'Arrange
        Dim expectedAddr As String = "test@test.com;test2@test.com"
        Dim msg As New MailMessage()
        Dim target As IStamp = New Stamp.Sender(expectedAddr)

        'Act
        target.Attach(msg)

        'Assert - exception
    End Sub
End Class