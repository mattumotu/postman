namespace Postman.Tests
{
    using System.Net.Mail;
    using System.Net.Mime;
    using Postman.Interfaces;
    using Xunit;

    /// <summary>
    /// This is a test class for EmbeddedResource and is intended to contain all EmbeddedResource Unit Tests
    /// </summary>
    public class EmbeddedResourceTest
    {
        /// <summary>
        /// A test for EmbeddedResource Constructor with steam and content type
        /// </summary>
        [Fact]
        public void EmbeddedResourceStreamContentTypeTest()
        {
            // Arrange
            int expectedAttachementCount = 1;
            string expectedViewText = "expectedViewText";
            ContentType expectedContentType = new ContentType("text/plain");
            AlternateView view = AlternateView.CreateAlternateViewFromString(expectedViewText, System.Text.Encoding.UTF8, MediaTypeNames.Text.Html);
            IEmbeddedResource target = new EmbeddedResource.EmbeddedResource(new System.IO.MemoryStream(), expectedContentType);

            // Act
            target.Embed(view);

            // Assert
            Assert.Equal(expectedAttachementCount, view.LinkedResources.Count);
            Assert.Equal(expectedContentType, view.LinkedResources[0].ContentType);
        }

        /// <summary>
        /// A test for EmbeddedResource Constructor with steam, content type and contentid
        /// </summary>
        [Fact]
        public void EmbeddedResourceStreamContentTypeContentIdTest()
        {
            // Arrange
            int expectedAttachementCount = 1;
            string expectedViewText = "expectedViewText";
            ContentType expectedContentType = new ContentType("text/plain");
            string expectedContentId = "expectedContentId";
            AlternateView view = AlternateView.CreateAlternateViewFromString(expectedViewText, System.Text.Encoding.UTF8, MediaTypeNames.Text.Html);
            IEmbeddedResource target = new EmbeddedResource.EmbeddedResource(new System.IO.MemoryStream(), expectedContentType, expectedContentId);

            // Act
            target.Embed(view);

            // Assert
            Assert.Equal(expectedAttachementCount, view.LinkedResources.Count);
            Assert.Equal(expectedContentType, view.LinkedResources[0].ContentType);
            Assert.Equal(expectedContentId, view.LinkedResources[0].ContentId);
        }

        /// <summary>
        /// A test for EmbeddedResource Constructor with filename and content type
        /// </summary>
        [Fact]
        public void EmbeddedResourceFilenameContentTypeTest()
        {
            // Arrange
            int expectedAttachementCount = 1;
            string expectedViewText = "expectedViewText";
            ContentType expectedContentType = new ContentType("text/plain");
            AlternateView view = AlternateView.CreateAlternateViewFromString(expectedViewText, System.Text.Encoding.UTF8, MediaTypeNames.Text.Html);
            IEmbeddedResource target = new EmbeddedResource.EmbeddedResource("Postman.dll", expectedContentType);

            // Act
            target.Embed(view);

            // Assert
            Assert.Equal(expectedAttachementCount, view.LinkedResources.Count);
            Assert.Equal(expectedContentType, view.LinkedResources[0].ContentType);
        }

        /// <summary>
        /// A test for EmbeddedResource Constructor with filename, content type and content id
        /// </summary>
        [Fact]
        public void EmbeddedResourceFilenameContentTypeContentIdTest()
        {
            // Arrange
            int expectedAttachementCount = 1;
            string expectedViewText = "expectedViewText";
            ContentType expectedContentType = new ContentType("text/plain");
            string expectedContentId = "expectedContentId";
            AlternateView view = AlternateView.CreateAlternateViewFromString(expectedViewText, System.Text.Encoding.UTF8, MediaTypeNames.Text.Html);
            IEmbeddedResource target = new EmbeddedResource.EmbeddedResource("Postman.dll", expectedContentType, expectedContentId);

            // Act
            target.Embed(view);

            // Assert
            Assert.Equal(expectedAttachementCount, view.LinkedResources.Count);
            Assert.Equal(expectedContentType, view.LinkedResources[0].ContentType);
            Assert.Equal(expectedContentId, view.LinkedResources[0].ContentId);
        }
    }
}