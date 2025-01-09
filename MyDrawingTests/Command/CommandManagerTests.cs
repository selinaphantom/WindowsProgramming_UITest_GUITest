using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing.Command;
using MyDrawing.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyDrawing.Command.Tests
{
    [TestClass()]
    public class CommandManagerTests
    {
        IShape _shape = new Start("123", 0, 0, 100, 100);
        Model _model = new Model();
        ICommand _Addcommand;
        ICommand _DrawLinecommand;
        [TestInitialize]
        public void Initialize()
        {
            _Addcommand = new ADDCommand(_model, "Start", "123", "123", "123", "123", "123");
            Line _line = new Line();
            _line.FinalPoint = "Top";
            _line.FristShape = _shape;
            _line.FinalPoint = "Left";
            _line.FinalShape = _shape;

            _DrawLinecommand = new DrawLineCommand(_model, _line);
        }
        [TestMethod()]
        public void ExecuteTest()
        {
            _model.AddCommand(_Addcommand);
            _model.AddCommand(_DrawLinecommand);
            Assert.AreEqual(1, _model.GetShapes().Count);
            Assert.AreEqual(1, _model.GetLines().Count);
        }

        [TestMethod()]
        public void UndoTest()
        {
            _model.AddCommand(_Addcommand);
            _model.AddCommand(_DrawLinecommand);
            Assert.AreEqual(true, _model.GetCommandUndoState());
            Assert.AreEqual(false, _model.GetCommandRedoState());
            Assert.AreEqual(1, _model.GetShapes().Count);
            Assert.AreEqual(1, _model.GetLines().Count);
            _model.RedoCommand();
            _model.UndoCommand();
            Assert.AreEqual(0, _model.GetLines().Count);
            Assert.AreEqual(true, _model.GetCommandRedoState());
            _model.UndoCommand();
            _model.UndoCommand();
        }

        [TestMethod()]
        public void RedoTest()
        {
            _model.AddCommand(_Addcommand);
            _model.AddCommand(_DrawLinecommand);
            _model.UndoCommand();
            Assert.AreEqual(0, _model.GetLines().Count);
            _model.RedoCommand();
            Assert.AreEqual(1, _model.GetLines().Count);
        }
        [TestMethod()]
        public void ClearTest()
        {
            _model.AddCommand(_Addcommand);
            _model.AddCommand(_DrawLinecommand);
            Assert.AreEqual(true, _model.GetCommandUndoState());
            Assert.AreEqual(false, _model.GetCommandRedoState());
            Assert.AreEqual(1, _model.GetShapes().Count);
            Assert.AreEqual(1, _model.GetLines().Count);
            _model.RedoCommand();
            _model.UndoCommand();
            Assert.AreEqual(0, _model.GetLines().Count);
            Assert.AreEqual(true, _model.GetCommandRedoState());
            _model.UndoCommand();
            _model.UndoCommand();
            _model.commands.ClearALL();
        }
    }
}