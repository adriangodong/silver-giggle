using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SilverGiggle.Tests
{
    [TestClass]
    public class EnvironmentVariableScopeTests
    {

        [TestMethod]
        public void Ctor_ShouldBackupRequestedVars()
        {
            // Arrange
            var varName = Guid.NewGuid().ToString("N");

            // Act
            using (var scope = new EnvironmentVariableScope(varName))
            {
                // Assert
                Assert.AreEqual(1, scope.OriginalValues.Count);
                Assert.AreEqual(varName, scope.OriginalValues.FirstOrDefault().Key);
            }
        }

        [TestMethod]
        public void Ctor_ShouldNotFailWithEmptyParam()
        {
            // Act
            using (var scope = new EnvironmentVariableScope())
            {
                // Assert
                Assert.AreEqual(0, scope.OriginalValues.Count);
            }
        }

        [TestMethod]
        public void UpdateEnvironmentVariable_ShouldBackupVar()
        {
            // Arrange
            var varName = Guid.NewGuid().ToString("N");
            using (var scope = new EnvironmentVariableScope())
            {
                // Act
                scope.UpdateEnvironmentVariable(varName, Guid.NewGuid().ToString("N"));

                // Assert
                Assert.AreEqual(1, scope.OriginalValues.Count);
                Assert.AreEqual(varName, scope.OriginalValues.FirstOrDefault().Key);
            }
        }

        [TestMethod]
        public void UpdateEnvironmentVariable_ShouldUpdateVar()
        {
            // Arrange
            var varName = Guid.NewGuid().ToString("N");
            var varValue = Guid.NewGuid().ToString("N");
            using (var scope = new EnvironmentVariableScope())
            {
                // Act
                scope.UpdateEnvironmentVariable(varName, varValue);

                // Assert
                Assert.AreEqual(varValue, Environment.GetEnvironmentVariable(varName));
            }
        }

        [TestMethod]
        public void Dispose_ShouldResetVar()
        {
            // Arrange
            var varName = Guid.NewGuid().ToString("N");
            var varValueOriginal = Guid.NewGuid().ToString("N");
            var varValueUpdated = Guid.NewGuid().ToString("N");

            Environment.SetEnvironmentVariable(varName, varValueOriginal);

            using (var scope = new EnvironmentVariableScope())
            {
                // Act
                scope.UpdateEnvironmentVariable(varName, varValueUpdated);

                // Assert
                Assert.AreEqual(varValueUpdated, Environment.GetEnvironmentVariable(varName));
            }

            Assert.AreEqual(varValueOriginal, Environment.GetEnvironmentVariable(varName));
        }

    }
}
