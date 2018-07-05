namespace Postman.Tests
{
    using System.Net.Mail;
    using Postman.Interfaces;
    using Postman.Stamp;
    using Xunit;

    /// <summary>
    /// This is a test class for RecipientStamp and is intended
    /// to contain all RecipientStamp Unit Tests
    /// </summary>
    public class RecipientStampTest
    {
        /// <summary>
        /// A test for RecipientStamp Constructor with a string containing a single email addresses
        /// </summary>
        [Fact]
        public void AddressString()
        {
            // Arrange
            int expectedCount = 1;
            string expectedAddr = "test@test.com";
            MailMessage msg = new MailMessage();
            IStamp target = new Recipient(expectedAddr);

            // Act
            target.Attach(msg);

            // Assert
            Assert.Equal(expectedCount, msg.To.Count);
            Assert.Equal(expectedAddr, msg.To[0].Address);
        }

        /// <summary>
        /// A test for RecipientStamp Constructor with a string containing muliple email addresses
        /// </summary>
        [Fact]
        public void MultipleAddressString()
        {
            // Arrange
            int expectedCount = 2;
            string expectedAddr1 = "test@test.com";
            string expectedAddr2 = "test2@test.com";
            string expectedAddrMulti = string.Format("{0}; {1}", expectedAddr1, expectedAddr2);
            MailMessage msg = new MailMessage();
            IStamp target = new Recipient(expectedAddrMulti);

            // Act
            target.Attach(msg);

            // Assert
            Assert.Equal(expectedCount, msg.To.Count);
            Assert.Equal(expectedAddr1, msg.To[0].Address);
            Assert.Equal(expectedAddr2, msg.To[1].Address);
        }

        /// <summary>
        /// A test for RecipientStamp Constructor with a string containing muliple email addresses
        /// </summary>
        [Fact]
        public void MultipleAddressStringEndsWithSemiColon()
        {
            // Arrange
            int expectedCount = 2;
            string expectedAddr1 = "test@test.com";
            string expectedAddr2 = "test2@test.com";
            string expectedAddrMulti = string.Format("{0}; {1};", expectedAddr1, expectedAddr2);
            MailMessage msg = new MailMessage();
            IStamp target = new Recipient(expectedAddrMulti);

            // Act
            target.Attach(msg);

            // Assert
            Assert.Equal(expectedCount, msg.To.Count);
            Assert.Equal(expectedAddr1, msg.To[0].Address);
            Assert.Equal(expectedAddr2, msg.To[1].Address);
        }

        /// <summary>
        /// A test for RecipientStamp Constructor with a string email address and string display name
        /// </summary>
        [Fact]
        public void AddressStringAndDisplayNameString()
        {
            // Arrange
            int expectedCount = 1;
            string expectedAddr = "test@test.com";
            string expectedDispName = "test user";
            MailMessage msg = new MailMessage();
            IStamp target = new Recipient(expectedAddr, expectedDispName);

            // Act
            target.Attach(msg);

            // Assert
            Assert.Equal(expectedCount, msg.To.Count);
            Assert.Equal(expectedAddr, msg.To[0].Address);
            Assert.Equal(expectedDispName, msg.To[0].DisplayName);
        }

        /// <summary>
        /// A test for RecipientStamp Constructor with a MailAddress
        /// </summary>
        [Fact]
        public void MailAddress()
        {
            int expectedCount = 1;
            MailAddress expectedAddr = new MailAddress("test@test.com", "test user");
            MailMessage msg = new MailMessage();
            IStamp target = new Recipient(expectedAddr);

            // Act
            target.Attach(msg);

            // Assert
            Assert.Equal(expectedCount, msg.To.Count);
            Assert.Equal(expectedAddr, msg.To[0]);
            Assert.Equal(expectedAddr.Address, msg.To[0].Address);
            Assert.Equal(expectedAddr.DisplayName, msg.To[0].DisplayName);
        }
    }
}