﻿using ManualTestExeForm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestAdd()
        {
            Assert.AreEqual(CalcLogic.Add(1, 2), 3);
        }

        [TestMethod]
        public void TestSub()
        {
            Assert.AreEqual(CalcLogic.Sub(1, 2), -1);
        }

        [TestMethod]
        public void TestMul()
        {
            Assert.AreEqual(CalcLogic.Mul(1, 2), 2);
        }

        [TestMethod]
        public void TestDiv()
        {
            Assert.AreEqual(CalcLogic.Div(1, 2), 0.5M);
            //Assert.AreEqual(CalcLogic.Div(1, 0), 0M);
        }
    }
}
