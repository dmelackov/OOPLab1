using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class RationalNumberTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            var a = new RationalNumber(2, 4);
            Assert.AreEqual(a.ToString(), "1/2");
        }
        [TestMethod()]
        public void ToStringTest2()
        {
            var a = new RationalNumber(2, -4);
            Assert.AreEqual(a.ToString(), "-1/2");
        }
        [TestMethod()]
        public void ToStringTest3()
        {
            var a = new RationalNumber(-2, -4);
            Assert.AreEqual(a.ToString(), "1/2");
        }
        [TestMethod()]
        public void ToStringTest4()
        {
            var a = new RationalNumber(-2, 4);
            Assert.AreEqual(a.ToString(), "-1/2");
        }

        [TestMethod()]
        public void SumTest1()
        {
            var a = new RationalNumber(1, 3);
            var b = new RationalNumber(2, 3);
            Assert.AreEqual((a + b).ToString(), "1");
            a = new RationalNumber(2, 3);
            b = new RationalNumber(1, 6);
            Assert.AreEqual((a + b).ToString(), "5/6");
        }
        [TestMethod()]
        public void SumTest2()
        {
            var a = new RationalNumber(2, 3);
            var b = new RationalNumber(1, 6);
            Assert.AreEqual((a + b).ToString(), "5/6");
        }
    }
}