Imports System.Net.Mail
Imports Postman

'''<summary>
'''This is a test class for CcStamp and is intended to contain all CcStamp Unit Tests
'''</summary>
<TestClass()> _
Public Class CcStampTest

    '''<summary>
    '''A test for CcStamp Constructor with a string containing a single email addresses
    '''</summary>
    <TestMethod()> _
    Public Sub AddressString()
        'Arrange
        Dim expectedCount As Integer = 1
        Dim expectedAddr As String = "test@test.com"
        Dim msg As New MailMessage()
        Dim target As IStamp = New Stamp.Cc(expectedAddr)

        'Act
        target.Attach(msg)

        'Assert
        Assert.AreEqual(expectedCount, msg.CC.Count)
        Assert.AreEqual(expectedAddr, msg.CC(0).Address)
    End Sub

    '''<summary>
    '''A test for CcStamp Constructor with a string containing muliple email addresses
    '''</summary>
    <TestMethod()> _
    Public Sub MultipleAddressString()
        'Arrange
        Dim expectedCount As Integer = 2
        Dim expectedAddr1 As String = "test@test.com"
        Dim expectedAddr2 As String = "test2@test.com"
        Dim expectedAddrMulti As String = String.Format("{0}; {1}", expectedAddr1, expectedAddr2)
        Dim msg As New MailMessage()
        Dim target As IStamp = New Stamp.Cc(expectedAddrMulti)

        'Act
        target.Attach(msg)

        'Assert
        Assert.AreEqual(expectedCount, msg.CC.Count)
        Assert.AreEqual(expectedAddr1, msg.CC(0).Address)
        Assert.AreEqual(expectedAddr2, msg.CC(1).Address)
    End Sub

    '''<summary>
    '''A test for CcStamp Constructor with a string containing muliple email addresses
    '''</summary>
    <TestMethod()> _
    Public Sub MultipleAddressStringEndsWithSemiColon()
        'Arrange
        Dim expectedCount As Integer = 2
        Dim expectedAddr1 As String = "test@test.com"
        Dim expectedAddr2 As String = "test2@test.com"
        Dim expectedAddrMulti As String = String.Format("{0}; {1};", expectedAddr1, expectedAddr2)
        Dim msg As New MailMessage()
        Dim target As IStamp = New Stamp.Cc(expectedAddrMulti)

        'Act
        target.Attach(msg)

        'Assert
        Assert.AreEqual(expectedCount, msg.CC.Count)
        Assert.AreEqual(expectedAddr1, msg.CC(0).Address)
        Assert.AreEqual(expectedAddr2, msg.CC(1).Address)
    End Sub

    '''<summary>
    '''A test for CcStamp Constructor with a string email address and string display name
    '''</summary>
    <TestMethod()> _
    Public Sub AddressStringAndDisplayNameString()
        'Arrange
        Dim expectedCount As Integer = 1
        Dim expectedAddr As String = "test@test.com"
        Dim expectedDispName As String = "test user"
        Dim msg As New MailMessage()
        Dim target As IStamp = New Stamp.Cc(expectedAddr, expectedDispName)

        'Act
        target.Attach(msg)

        'Assert
        Assert.AreEqual(expectedCount, msg.CC.Count)
        Assert.AreEqual(expectedAddr, msg.CC(0).Address)
        Assert.AreEqual(expectedDispName, msg.CC(0).DisplayName)
    End Sub

    '''<summary>
    '''A test for CcStamp Constructor with a MailAddress
    '''</summary>
    <TestMethod()> _
    Public Sub MailAddress()
        Dim expectedCount As Integer = 1
        Dim expectedAddr As New MailAddress("test@test.com", "test user")
        Dim msg As New MailMessage()
        Dim target As IStamp = New Stamp.Cc(expectedAddr)

        'Act
        target.Attach(msg)

        'Assert
        Assert.AreEqual(expectedCount, msg.CC.Count)
        Assert.AreEqual(expectedAddr, msg.CC(0))
        Assert.AreEqual(expectedAddr.Address, msg.CC(0).Address)
        Assert.AreEqual(expectedAddr.DisplayName, msg.CC(0).DisplayName)
    End Sub
End Class