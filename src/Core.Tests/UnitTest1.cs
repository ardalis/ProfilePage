using System;
using Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var service = new ProfileLevelService();

            var levels = service.GetLevels();

            foreach (var level in levels)
            {
                Console.WriteLine(level);
            }
        }
    }
}
