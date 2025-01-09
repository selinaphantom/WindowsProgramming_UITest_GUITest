using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.Command;
using MyDrawing.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Command.Tests
{
    [TestClass()]
    public class DrawCommandTests
    {
        Model _model = new Model();
        IShape _shape = new Start("123", 0, 0, 100, 100);
        ICommand _Drawcommand;
        [TestInitialize]
        public void Initialize()
        {
            _Drawcommand = new DrawCommand(_model, _shape);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            _Drawcommand.Execute();
            Assert.AreEqual(1, _model.GetShapes().Count);
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            _Drawcommand.Execute();
            Assert.AreEqual(1, _model.GetShapes().Count);
            _Drawcommand.UnExecute();
            Assert.AreEqual(0, _model.GetShapes().Count);
        }
    }
}