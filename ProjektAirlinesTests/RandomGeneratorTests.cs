using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjektAirlines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektAirlines.Tests
{
    [TestClass()]
    public class RandomGeneratorTests
    {
        [TestMethod()]
        public void RandomNumberTest()
        {
            
            bool test=false;
            Random _random = new Random();
            int x = _random.Next(50, 1000);
            for (int i = 0; i < 100; i++)
            {
                if (x >= 50 && x <= 1000)
                    test = true;

                else
                {
                    test = false;
                    break;
                }
            }
            Assert.IsTrue(test);
        }
    }
}