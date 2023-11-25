using NUnit.Framework;
using System;
using Zad5;


namespace Zad5Tests
{
    [TestFixture]
    public class ConnectStringsTests
    {
        [Test]
        public void Connect_WithNonNullStrings_ShouldReturnConcatenatedString()
        {
            // Arrange
            var connectStrings = new ConnectStrings();
            var first = "Hello";
            var second = "World";

            // Act
            var result = connectStrings.Connect(first, second);

            // Assert
            Assert.That(result, Is.EqualTo("HelloWorld"));
        }
        
        [Test]
        public void Connect_WithEmptyFirstString_ShouldReturnSecondString()
        {
            // Arrange
            var connectStrings = new ConnectStrings();
            var first = "";
            var second = "World";

            // Act
            var result = connectStrings.Connect(first, second);

            // Assert
            Assert.That(result, Is.EqualTo("World"));
        }

        [Test]
        public void Connect_WithNullFirstString_ShouldReturnNull()
        {
            // Arrange
            var connectStrings = new ConnectStrings();
            string first = null;
            var second = "World";

            // Act
            var result = connectStrings.Connect(first, second);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Connect_WithNullSecondString_ShouldReturnNull()
        {
            // Arrange
            var connectStrings = new ConnectStrings();
            var first = "Hello";
            string second = null;

            // Act
            var result = connectStrings.Connect(first, second);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Connect_WithBothNullStrings_ShouldReturnNull()
        {
            // Arrange
            var connectStrings = new ConnectStrings();
            string first = null;
            string second = null;

            // Act
            var result = connectStrings.Connect(first, second);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
    
    [TestFixture]
    public class ConnectStringsWithExceptionTests
    {
        [Test]
        [TestCase(null, "World")]
        [TestCase("Hello", null)]
        [TestCase(null, null)]
        public void Connect_WithNullArgument_ShouldThrowArgumentNullException(string first, string second)
        {
            // Arrange
            var connectStrings = new ConnectStringsWithException();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => connectStrings.Connect(first, second));
        }

        [Test]
        public void Connect_WithNonNullStrings_ShouldReturnConcatenatedString()
        {
            // Arrange
            var connectStrings = new ConnectStringsWithException();
            var first = "Hello";
            var second = "World";

            // Act
            var result = connectStrings.Connect(first, second);

            // Assert
            Assert.That(result, Is.EqualTo("HelloWorld"));
        }
    }
}