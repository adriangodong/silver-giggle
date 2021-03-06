﻿using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SilverGiggle.Tests
{
    [TestClass]
    public class InternalResourceManagerTests
    {

        [TestMethod]
        public void Ctor_ShouldPopulateFieldsFromRootTypeCorrectly()
        {
            // Arrange
            var rootType = typeof(InternalResourceManagerTests);

            // Act
            var internalResourceManager = new InternalResourceManager(rootType.GetTypeInfo());

            // Assert
            Assert.AreEqual(rootType.GetTypeInfo().Assembly, internalResourceManager.Assembly);
            Assert.AreEqual("SilverGiggle.Tests", internalResourceManager.ResourceNamespace);
        }

        [TestMethod]
        public void GetString_ShouldReturnEmbeddedValue()
        {
            // Arrange
            var rootType = typeof(InternalResourceManagerTests);
            var internalResourceManager = new InternalResourceManager(rootType.GetTypeInfo());

            // Act
            var value = internalResourceManager.GetString("test-resource.txt");

            // Assert
            Assert.AreEqual("Hello world!", value);
        }

        [TestMethod]
        public void GetString_ShouldThrowArgumentException_WhenNameNotFound()
        {
            // Arrange
            var rootType = typeof(InternalResourceManagerTests);
            var internalResourceManager = new InternalResourceManager(rootType.GetTypeInfo());

            // Act
            Assert.ThrowsException<ArgumentException>(
                () => internalResourceManager.GetString(Guid.NewGuid().ToString("N")));
        }

    }
}
