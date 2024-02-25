using Microsoft.VisualStudio.TestTools.UnitTesting;
using Statistics;
using System.IO;
using Newtonsoft.Json;

namespace Statistics.Tests
{
    [TestClass]
    public class StatisticsTests
    {

        [TestMethod]
        public void Maximum_ReturnsCorrectValue()
        {
            int expected = 10;
            int actual = Statistics.Maximum(); // Anropa metoden utan parameter
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Minimum_ReturnsCorrectValue()
        {
            int expected = 1;
            int actual = Statistics.Minimum(); // Anropa metoden utan parameter
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Mean_ReturnsCorrectValue()
        {
            double expected = 5.5;
            double actual = Statistics.Mean(); // Anropa metoden utan parameter
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Median_ReturnsCorrectValue()
        {
            double expected = 5.5;
            double actual = Statistics.Median(); // Anropa metoden utan parameter
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Mode_ReturnsCorrectValue()
        {
            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }; // Testa hela datan
            int[] actual = Statistics.Mode(); // Anropa metoden utan parameter
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Range_ReturnsCorrectValue()
        {
            int expected = 9;
            int actual = Statistics.Range(); // Anropa metoden utan parameter
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StandardDeviation_ReturnsCorrectValue()
        {
            double expected = 2.9; // För att matcha avrundningen.
            double actual = Statistics.StandardDeviation(); // Anropa metoden utan parameter
            Assert.AreEqual(expected, actual);
        }
    }
}

// Den kan inte hitta JSON-filen.