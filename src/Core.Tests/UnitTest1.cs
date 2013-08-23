using System;
using Core.Services;
using NUnit.Framework;

namespace Core.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
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
