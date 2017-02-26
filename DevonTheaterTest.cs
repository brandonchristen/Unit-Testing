using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenRA.Graphics;

namespace UnitTestProject1
{
    [TestClass]
    public class DevonTheaterTest
    {
        [TestMethod]
        public void testTheater()
        {
            Theater testTheater = new Theater(new OpenRA.TileSet(null, null));
            Assert.IsNotNull(testTheater);
        }
    }
}
