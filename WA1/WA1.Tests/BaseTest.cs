using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WA1.Tests.IocRegistration;

namespace WA1.Tests
{
    [TestClass]
    public class BaseTest : IoCSupportedTest
    {
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestCleanup]
        public void CleanUp()
        {
            ShutdownIoC();
        }
    }
}
