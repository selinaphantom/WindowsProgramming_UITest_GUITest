using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing;
using MyDrawing.Shape;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.DataFormats;

namespace MyDrawing.Tests
{
    [TestClass()]
    public class PresentationStateModelTests
    {
        PresentationStateModel _presentationModel = new PresentationStateModel();
        Model _model = new Model();
        bool _NotifyPresentationModel = false;
        [TestInitialize()]
        public void Initialize()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string folderName = "drawing_backup";
            string folderPath = Path.Combine(basePath, folderName);
            Directory.CreateDirectory(folderPath);
            Console.WriteLine($"資料夾已建立：{folderPath}");

        }
        [TestMethod()]
        public void ButtonCheckedTest()
        {
            _presentationModel.ButtonChecked(_model);
            _presentationModel.ButtonChecked(_model, "UsingStart");
            _presentationModel.ButtonChecked(_model, "UsingTerminator");
            _presentationModel.ButtonChecked(_model, "UsingProcess");
            _presentationModel.ButtonChecked(_model, "UsingDecision");
            _presentationModel.ButtonChecked(_model, "UsingLine");
            Assert.AreEqual(true, _presentationModel.CurrentState);
            Assert.AreEqual(true, _presentationModel.LineState);
        }
        [TestMethod()]
        public void CheckErrorTest()
        {
            _presentationModel.CheckError(1, "asd", "0", "0", "100", "100", _model);
            _presentationModel.NotifyPropertyChanged("AddShapeEnabled");
            Assert.AreEqual(true, _presentationModel.AddShapeEnabled);
            Assert.AreEqual("ControlText", _presentationModel.Textcolor);
            Assert.AreEqual("ControlText", _presentationModel.Xcolor);
            Assert.AreEqual("ControlText", _presentationModel.Ycolor);
            Assert.AreEqual("ControlText", _presentationModel.Widthcolor);
            Assert.AreEqual("ControlText", _presentationModel.Heightcolor);
            _presentationModel.CheckError(1, "asd", "0", "asd0", "100", "100", _model);
            Assert.AreEqual(false, _presentationModel.AddShapeEnabled);
            Assert.AreEqual("ControlText", _presentationModel.Textcolor);
            Assert.AreEqual("ControlText", _presentationModel.Xcolor);
            Assert.AreEqual("Red", _presentationModel.Ycolor);
            Assert.AreEqual("ControlText", _presentationModel.Widthcolor);
            Assert.AreEqual("ControlText", _presentationModel.Heightcolor);
        }
        [TestMethod()]
        public void EnabledTest()
        {
            _presentationModel.ButtonChecked(_model, "UsingStart");
            Assert.AreEqual(true, _presentationModel.StartState);
            Assert.AreEqual(false, _presentationModel.TerminatorState);
            Assert.AreEqual(false, _presentationModel.ProcessState);
            Assert.AreEqual(false, _presentationModel.DecisionState);
            _presentationModel.ButtonChecked(_model, "UsingTerminator");
            Assert.AreEqual(false, _presentationModel.StartState);
            Assert.AreEqual(true, _presentationModel.TerminatorState);
            Assert.AreEqual(false, _presentationModel.ProcessState);
            Assert.AreEqual(false, _presentationModel.DecisionState);
        }

        [TestMethod()]
        public void NotifyPropertyChangedTest()
        {

            Assert.IsFalse(_NotifyPresentationModel);

            _presentationModel.NotifyPropertyChanged("AddShapeEnabled");
            Assert.IsFalse(_NotifyPresentationModel);

            _presentationModel.PropertyChanged += Eventtests;
            _presentationModel.NotifyPropertyChanged("AddShapeEnabled");
            Assert.IsTrue(_NotifyPresentationModel);
        }
        public void Eventtests(object sender, PropertyChangedEventArgs e)
        {
            _NotifyPresentationModel = true;
        }
        [TestMethod()]
        public void DataViewDelClickChangedTest()
        {
            _presentationModel._DataSize = 2;
            _model.ADDShapeFormDrawState(new Start("123", 0, 0, 100, 100));
            _model.ADDShapeFormDrawState(new Start("345", 200, 345, 100, 100));
            Line _line1 = new Line();
            _line1.FinalPoint = "Top";
            _line1.FristShape = _model.GetShapes()[0];
            _line1.FinalPoint = "Left";
            _line1.FinalShape = _model.GetShapes()[1];
            Line _line2 = new Line();
            _line2.FinalPoint = "Left";
            _line2.FristShape = _model.GetShapes()[0];
            _line2.FinalPoint = "Top";
            _line2.FinalShape = _model.GetShapes()[1];
            _model.AddLine(_line1);
            _model.AddLine(_line2);
            _presentationModel.DataViewDelClick(_model, 3, 3, 0);
            Assert.AreEqual(0, _model.GetLines().Count);
            _model.UndoCommand();
            _model.UndoCommand();
            _model.UndoCommand();
            Assert.AreEqual(2, _model.GetLines().Count);
            _presentationModel.DataViewDelClick(_model, 3, 3, 2);
            Assert.AreEqual(1, _model.GetLines().Count);
        }
        [TestMethod]
        public async Task SavingTest()  // 改為 async Task
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string folderName = "drawing_backup";
            string folderPath = Path.Combine(basePath, folderName);
            _model.ADDShapeFormDrawState(new Start("123", 0, 0, 100, 100));
            _model.ADDShapeFormDrawState(new Start("345", 200, 345, 100, 100));
            Line _line1 = new Line();
            _line1.FinalPoint = "Top";
            _line1.FristShape = _model.GetShapes()[0];
            _line1.FinalPoint = "Left";
            _line1.FinalShape = _model.GetShapes()[1];
            Line _line2 = new Line();
            _line2.FinalPoint = "Left";
            _line2.FristShape = _model.GetShapes()[0];
            _line2.FinalPoint = "Top";
            _line2.FinalShape = _model.GetShapes()[1];
            _model.AddLine(_line1);
            _model.AddLine(_line2);
            string backupFolder = Path.Combine(basePath, "drawing_backup");
            _presentationModel.checkfilenum(backupFolder);
            DateTime now = DateTime.Now;
            string formattedDateTime = now.ToString("yyyyMMddHHmmss");
            await _presentationModel.SaveShapesAsync(_model, "drawing_backup/" + "UnitTest" + "_bak.mydrawing");
            await _presentationModel.SaveShapesAsync(_model, "drawing_backup/" + "1" + "_bak.mydrawing");
            await _presentationModel.SaveShapesAsync(_model, "drawing_backup/" + "2" + "_bak.mydrawing");
            await _presentationModel.SaveShapesAsync(_model, "drawing_backup/" + "3" + "_bak.mydrawing");
            await _presentationModel.SaveShapesAsync(_model, "drawing_backup/" + "4" + "_bak.mydrawing");
            await _presentationModel.SaveShapesAsync(_model, "drawing_backup/" + "5" + "_bak.mydrawing");




            Assert.IsTrue(File.Exists("drawing_backup/" + "UnitTest" + "_bak.mydrawing"));
        }
        [TestMethod]
        public void UpLoadTest()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string folderName = "drawing_backup";
            string folderPath = Path.Combine(basePath, folderName);
            string backupFolder = Path.Combine(basePath, "drawing_backup");
            _presentationModel.checkfilenum(backupFolder);
            _presentationModel.LoadShapes(_model, "drawing_backup/" + "UnitTest" + "_bak.mydrawing");
        }
    }
}
