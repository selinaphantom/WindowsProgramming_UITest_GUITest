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
    public class TextChangeCommandTests
    {
        Model _model = new Model();
        ICommand _ADDcommand;
        ICommand _TextChangecommand;
        [TestInitialize]
        public void Initialize()
        {
            _ADDcommand = new ADDCommand(_model, "Start", "123", "0", "0", "123", "123");
            _model.AddCommand(_ADDcommand);
            _TextChangecommand = new TextChangeCommand(_model, _model.GetShapes()[0], "222", "123");
        }
        [TestMethod()]
        public void ExecuteTest()
        {
            _TextChangecommand.Execute();
            Assert.AreEqual("222", _model.GetShapes()[0]._ShapeText);
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            _TextChangecommand.Execute();
            Assert.AreEqual("222", _model.GetShapes()[0]._ShapeText);
            _TextChangecommand.UnExecute();
            Assert.AreEqual("123", _model.GetShapes()[0]._ShapeText);
        }
    }
}