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
    public class TextMoveCommandTests
    {
        Model _model = new Model();
        IShape _shape = new Start("123", 0, 0, 100, 100);
        ICommand _TextMovecommand;
        [TestInitialize]
        public void Initialize()
        {
            _model.ADDShapeFormDrawState(_shape);
            _TextMovecommand = new TextMoveCommand(_model, _model.GetShapes()[0], 0, 0, 100, 100);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            _TextMovecommand.Execute();
            Assert.AreEqual(100, _model.GetShapes()[0]._TextX);
            Assert.AreEqual(100, _model.GetShapes()[0]._TextY);
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            _TextMovecommand.Execute();
            Assert.AreEqual(100, _model.GetShapes()[0]._TextX);
            Assert.AreEqual(100, _model.GetShapes()[0]._TextY);
            _TextMovecommand.UnExecute();
            Assert.AreEqual(0, _model.GetShapes()[0]._TextX);
            Assert.AreEqual(0, _model.GetShapes()[0]._TextY);
        }
    }
}