using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjektAirlines;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DistanceTest()
        {
            //Arrange
            string destination = "Dubai";
            string source = "Warsaw";
            int distanceExpected = 155;

            //Act
            var distanceTest = new Functions();
            var flightDistance = distanceTest.Distance(source, destination);

            //Assert
            Assert.AreEqual(distanceExpected, flightDistance);
            
        }

        [TestMethod]
        public void FlightPriceTest()
        {
            //Arrange
            int distance = 155;
            int index = 0;
            decimal people = 1;
            int priceExpected = 310;

            //Act
            var priceTest = new Functions();
            var flightPrice = priceTest.FlightPrice(distance, people, index);

            //Assert
            Assert.AreEqual(310, flightPrice);
            

        }
    }

   
}
