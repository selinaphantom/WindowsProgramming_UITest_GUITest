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
    public class DeleteLineCommandTests
    {
        Model _model = new Model();
        IShape _shape = new Start("123", 0, 0, 100, 100);
        ICommand _ADDcommand;
        ICommand _DelLinecommand;
        [TestInitialize]
        public void Initialize()
        {
            Line _line = new Line();
            _line.FinalPoint = "Top";
            _line.FristShape = _shape;
            _line.FinalPoint = "Left";
            _line.FinalShape = _shape;
            _model.ADDShapeFormDrawState(_shape);
            _model.AddLine(_line);
            _DelLinecommand = new DeleteLineCommand(_model, _model.GetLines()[0], 0);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            _DelLinecommand.Execute();
            Assert.AreEqual(0, _model.GetLines().Count);
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            _DelLinecommand.Execute();
            Assert.AreEqual(0, _model.GetLines().Count);
            _DelLinecommand.UnExecute();
            Assert.AreEqual(1, _model.GetLines().Count);
        }
    }
}