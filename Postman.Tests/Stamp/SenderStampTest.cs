namespace Postman.Tests
{
    using System.Net.Mail;
    using Postman.Stamp;
    using Xunit;

    /// <summary>
    ///  This is a test class for SenderStamp and is intended to contain all SenderStamp Unit Tests
    /// </summary>
    public class SenderStampTest
    {
        /// <summary>
        /// A test for SenderStamp Constructor with a string containing a single email addresses
        /// </summary>
        [Fact]
        public void AddressString()
        {
            // Arrange
            string expectedAddr = "test@test.com";
            MailMessage msg = new MailMessage();
            IStamp target = new Sender(expectedAddr);

            // Act
            target.Attach(msg);

            // Assert
            Assert.Equal(expectedAddr, msg.Sender.Address);
        }

        /// <summary>
        /// A test for SenderStamp Constructor with a string email address and string display name
        /// </summary>
        [Fact]
        public void AddressStringAndDisplayNameString()
        {
            // Arrange
            string expectedAddr = "test@test.com";
            string expectedDispName = "test user";
            MailMessage msg = new MailMessage();
            IStamp target = new Sender(expectedAddr, expectedDispName);

            // Act
            target.Attach(msg);

            // Assert
            Assert.Equal(expectedAddr, msg.Sender.Address);
            Assert.Equal(expectedDispName, msg.Sender.DisplayName);
        }

        /// <summary>
        /// A test for SenderStamp Constructor with a MailAddress
        /// </summary>
        [Fact]
        public void MailAddress()
        {
            // Arrange
            MailAddress expectedAddr = new MailAddress("test@test.com", "test user");
            MailMessage msg = new MailMessage();
            IStamp target = new Sender(expectedAddr);

            // Act
            target.Attach(msg);

            // Assert
            Assert.Equal(expectedAddr, msg.Sender);
            Assert.Equal(expectedAddr.Address, msg.Sender.Address);
            Assert.Equal(expectedAddr.DisplayName, msg.Sender.DisplayName);
        }

        ///  <summary>
        ///  A test for SenderStamp Contructor with multiple addresses
        ///  </summary>
        [Fact]
        public void MultipleSendersThrowsException()
        {
            // Arrange
            string expectedAddr = "test@test.com;test2@test.com";
            MailMessage msg = new MailMessage();
            IStamp target;

            // Act  & Assert
            System.Exception ex = Assert.Throws<System.FormatException>(() => target = new Sender(expectedAddr));

            // Assert
            Assert.Equal("An invalid character was found in the mail header: ';'.", ex.Message);
        }
    }
}