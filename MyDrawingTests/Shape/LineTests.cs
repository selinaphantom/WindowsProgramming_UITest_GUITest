using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Shape.Tests
{
    [TestClass()]
    public class LineTests
    {
        Model _model = new Model();
        [TestInitialize()]
        public void Initialize()
        {
        }


        [TestMethod()]
        public void GetPointXTest()
        {
            _model.ADDShapeFormDrawState(new Start("123",0,0,100,100));
            Line line = new Line();
            line.FristX = 0;
            line.FristY = 0;
            Assert.AreEqual(0, line.FristX);
            Assert.AreEqual(0, line.FristY);
        }

        [TestMethod()]
        public void GetPointYTest()
        {
            _model.ADDShapeFormDrawState(new Start("123", 0, 0, 100, 100));
            Line line = new Line();
            Assert.AreEqual(50, line.GetPointX(new Start("123", 0, 0, 100, 100), "Top"));
            Assert.AreEqual(100, line.GetPointX(new Start("123", 0, 0, 100, 100), "Right"));
            Assert.AreEqual(50, line.GetPointX(new Start("123", 0, 0, 100, 100), "Bottom"));
            Assert.AreEqual(0, line.GetPointX(new Start("123", 0, 0, 100, 100), "Left"));
            Assert.AreEqual(0, line.GetPointX(new Start("123", 0, 0, 100, 100), ""));
            Assert.AreEqual(0, line.GetPointY(new Start("123", 0, 0, 100, 100), "Top"));
            Assert.AreEqual(50, line.GetPointY(new Start("123", 0, 0, 100, 100), "Right"));
            Assert.AreEqual(100, line.GetPointY(new Start("123", 0, 0, 100, 100), "Bottom"));
            Assert.AreEqual(50, line.GetPointY(new Start("123", 0, 0, 100, 100), "Left"));
            Assert.AreEqual(0, line.GetPointY(new Start("123", 0, 0, 100, 100), ""));
        }
    }
}