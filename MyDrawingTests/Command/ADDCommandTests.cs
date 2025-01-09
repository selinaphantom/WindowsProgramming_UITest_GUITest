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
    public class ADDCommandTests
    {
        Model _model = new Model();
        ICommand _command;
        [TestInitialize]
        public void Initialize()
        {
            _command = new ADDCommand(_model, "Start", "123", "123", "123", "123", "123");
        }

        [TestMethod()]
        public void ExecuteTest()
        {
            _command.Execute();
            Assert.AreEqual(1, _model.GetShapes().Count);
        }

        [TestMethod()]
        public void UnExecuteTest()
        {
            _command.UnExecute();
            Assert.AreEqual(0, _model.GetShapes().Count);
        }
    }
}