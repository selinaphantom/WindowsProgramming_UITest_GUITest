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
    public class DrawLineCommandTests
    {
        Model _model = new Model();
        IShape _shape = new Start("123", 0, 0, 100, 100);
        ICommand _Drawcommand;
        [TestInitialize]
        public void Initialize()
        {
            Line _line = new Line();
            _line.FinalPoint = "Top";
            _line.FristShape = _shape;
            _line.FinalPoint = "Left";
            _line.FinalShape = _shape;
            _Drawcommand = new DrawLineCommand(_model, _line);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            _Drawcommand.Execute();
            Assert.AreEqual(1, _model.GetLines().Count);
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            _Drawcommand.Execute();
            Assert.AreEqual(1, _model.GetLines().Count);
            _Drawcommand.UnExecute();
            Assert.AreEqual(0, _model.GetLines().Count);
        }
    }
}