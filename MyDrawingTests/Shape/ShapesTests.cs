using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Tests
{
    [TestClass()]
    public class ShapesTests
    {
        Shapes shape = new Shapes();
        [TestInitialize()]
        public void Initialize()
        {
        }
        [TestMethod()]
        public void CreateTest()
        {
            shape.CreateShape("UsingStart", "123", "0", "0", "0", "0");
            Assert.AreEqual("Start", shape.GetAllShape()[0]._ShapeName);
            Assert.AreEqual(10, shape.GetAllShape()[0]._ShapeHeight);
            Assert.AreEqual(10, shape.GetAllShape()[0]._ShapeWidth);
        }
    }
}
