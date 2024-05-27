using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Test2.Common.Service;

namespace Test2.UnitTest
{
    [TestClass]
    public class StringCalculatorTests
    {
        [TestMethod]
        public void Add_EmptyString_ReturnsZero()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            int result = calculator.Add("");

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_SingleNumber_ReturnsNumber()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            int result = calculator.Add("5");

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Add_TwoNumbers_ReturnsSum()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            int result = calculator.Add("5,7");

            // Assert
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void Add_NewLinesBetweenNumbers_ReturnsSum()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            int result = calculator.Add("1\n2,3");

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_CustomDelimiter_ReturnsSum()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            int result = calculator.Add("//;\n1;2");

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_NegativeNumbers_ThrowsException()
        {
            // Arrange
            var calculator = new Calculator();

            // Act & Assert
            var ex = Assert.ThrowsException<Exception>(() => calculator.Add("1,-2,3"));
            Assert.AreEqual("Negatives not allowed: -2", ex.Message);
        }
    }
}
