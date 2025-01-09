using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Command.Tests
{
    [TestClass()]
    public class MoveCommandTests
    {
        Model _model = new Model();
        IShape _shape = new Start("123", 0, 0, 100, 100);
        ICommand _Movecommand;
        [TestInitialize]
        public void Initialize()
        {
            _model.ADDShapeFormDrawState(_shape);
            _Movecommand = new MoveCommand(_model, _model.GetShapes()[0], 0, 0, 100, 100);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            _Movecommand.Execute();
            Assert.AreEqual(100, _model.GetShapes()[0]._ShapeX);
            Assert.AreEqual(100, _model.GetShapes()[0]._ShapeY);
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            _Movecommand.Execute();
            Assert.AreEqual(100, _model.GetShapes()[0]._ShapeX);
            Assert.AreEqual(100, _model.GetShapes()[0]._ShapeY);
            _Movecommand.UnExecute();
            Assert.AreEqual(0, _model.GetShapes()[0]._ShapeX);
            Assert.AreEqual(0, _model.GetShapes()[0]._ShapeY);
        }
    }
}