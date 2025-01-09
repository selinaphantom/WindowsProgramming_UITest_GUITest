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
    public class DeleteCommandTests
    {
        Model _model = new Model();
        IShape _shape = new Start("123", 0, 0, 100, 100);
        ICommand _ADDcommand;
        ICommand _Delcommand;
        [TestInitialize]
        public void Initialize()
        {
            _ADDcommand = new ADDCommand(_model, "Start", "123", "123", "123", "123", "123");
            _model.AddCommand(_ADDcommand);
            _Delcommand = new DeleteCommand(_model, _model.GetShapes()[0], 0);
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            _Delcommand.Execute();
            Assert.AreEqual(0, _model.GetShapes().Count);
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            _Delcommand.Execute();
            Assert.AreEqual(0, _model.GetShapes().Count);
            _Delcommand.UnExecute();
            Assert.AreEqual(1, _model.GetShapes().Count);
        }
    }
}