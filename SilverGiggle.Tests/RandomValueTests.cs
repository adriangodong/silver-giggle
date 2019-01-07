using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SilverGiggle.Tests
{
    [TestClass]
    public class RandomValueTests
    {
        [TestMethod]
        public void NextGuid_ReturnsRandomValue()
        {
            // Act
            var value1 = RandomValue.NextGuid();
            var value2 = RandomValue.NextGuid();

            // Assert
            Assert.AreNotEqual(value1, value2);
        }

        [TestMethod]
        public void NextString_ReturnsRandomValue()
        {
            // Act
            var value1 = RandomValue.NextString();
            var value2 = RandomValue.NextString();

            // Assert
            Assert.AreNotEqual(value1, value2);
        }

        [TestMethod]
        public void NextInt32_ReturnsRandomValue()
        {
            // Act
            var value1 = RandomValue.NextInt32();
            var value2 = RandomValue.NextInt32();

            // Assert
            Assert.AreNotEqual(value1, value2);
        }

        [TestMethod]
        public void NextDouble_ReturnsRandomValue()
        {
            // Act
            var value1 = RandomValue.NextDouble();
            var value2 = RandomValue.NextDouble();

            // Assert
            Assert.AreNotEqual(value1, value2);
        }

        [TestMethod]
        public void NextInt64_ReturnsRandomValue()
        {
            // Act
            var value1 = RandomValue.NextInt64();
            var value2 = RandomValue.NextInt64();

            // Assert
            Assert.AreNotEqual(value1, value2);
        }

        [TestMethod]
        public void NextDateTimeOffset_ReturnsRandomValue()
        {
            // Act
            var value1 = RandomValue.NextDateTimeOffset();
            var value2 = RandomValue.NextDateTimeOffset();

            // Assert
            Assert.AreNotEqual(value1, value2);
        }
    }
}
