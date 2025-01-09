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
    public class DecisionTests
    {
        IShape shape = new Decision("123", 0, 0, 100, 100);
        List<string> _task = new List<string>();
        IGraphics graphics;
        [TestInitialize()]
        public void Initialize()
        {
            graphics = new MockGraphic(_task);
        }
        [TestMethod()]
        public void DrawTest()
        {
            Assert.IsFalse(shape._IsDraw);
            shape.Draw(graphics);
            shape.DrawEdge(graphics);
            Assert.IsTrue(shape._IsDraw);
        }
        [TestMethod()]
        public void CheckTest()
        {
            Assert.AreEqual(true, shape.CheckInPoint(50, 50));
        }
        [TestMethod()]
        public void TextCheckTest()
        {
            float x = (float)(shape._TextX + shape._ShapeX + shape._ShapeWidth / 2.5) + (float)(shape._ShapeText.Length * 2.48) + 3;
            float y = (float)(shape._TextY + shape._ShapeY + shape._ShapeHeight / 2.5) - 10 + 3;
            Assert.AreEqual(true, shape.IsMouseOverCircle((int)x, (int)y));
            Assert.AreEqual(false, shape.IsMouseOverCircle(10, 10));
        }
        [TestMethod()]
        public void DrawLinePointTest()
        {
            shape.DrawLinePoint(graphics);
            Assert.AreEqual(4, _task.Count);
        }
        [TestMethod()]
        public void IsPointInLinePointTest()
        {
            Assert.AreEqual(true, shape.IsPointInLinePoint(50, 0, "Top"));
            Assert.AreEqual(true, shape.IsPointInLinePoint(100, 50, "Right"));
            Assert.AreEqual(true, shape.IsPointInLinePoint(50, 100, "Bottom"));
            Assert.AreEqual(true, shape.IsPointInLinePoint(0, 50, "Left"));
            Assert.AreEqual(false, shape.IsPointInLinePoint(0, 0, "Top"));
        }
    }
}
