using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static MyDrawing.Model;
using static System.Net.Mime.MediaTypeNames;

namespace MyDrawing.Tests
{
    [TestClass()]
    public class ModelTests
    {
        Model _model = new Model();
        bool _NotifyModel = false;
        [TestInitialize()]
        public void Initialize()
        {

        }
        //Model測試
        [TestMethod()]
        public void ModelTest()
        {
            Model model = new Model();
            Assert.AreEqual(true, model._UseState);
        }

        [TestMethod()]
        public void AddShapeTest()
        {
            _model.AddShape("UsingStart", "123", "0", "0", "100", "100");
            _model.AddShape("UsingTerminator", "123", "0", "0", "100", "100");
            _model.AddShape("UsingProcess", "123", "0", "0", "100", "100");
            _model.AddShape("UsingDecision", "123", "0", "0", "100", "100");
            Assert.AreEqual("Start", _model.GetShapes()[0]._ShapeName);
            Assert.AreEqual("Terminator", _model.GetShapes()[1]._ShapeName);
            Assert.AreEqual("Process", _model.GetShapes()[2]._ShapeName);
            Assert.AreEqual("Decision", _model.GetShapes()[3]._ShapeName);
        }
        [TestMethod()]
        public void DeleteShapeeTest()
        {
            _model.AddShape("UsingStart", "123", "0", "0", "100", "100");
            _model.AddShape("UsingTerminator", "123", "0", "0", "100", "100");
            _model.AddShape("UsingProcess", "123", "0", "0", "100", "100");
            _model.AddShape("UsingDecision", "123", "0", "0", "100", "100");
            _model.DeleteShape(1);
            Assert.AreEqual("Start", _model.GetShapes()[0]._ShapeName);
            Assert.AreEqual("Process", _model.GetShapes()[1]._ShapeName);
            Assert.AreEqual("Decision", _model.GetShapes()[2]._ShapeName);
        }
        [TestMethod()]
        public void CheckChooseStateCorrectTest()
        {
            Assert.AreEqual(true, _model.CheckChooseStateCorrect(1));
            Assert.AreEqual(false, _model.CheckChooseStateCorrect(-1));
        }
        [TestMethod()]
        public void CheckTextCorrectTest()
        {
            Assert.AreEqual("ControlText", _model.CheckTextCorrect("1231"));
            Assert.AreEqual("Red", _model.CheckTextCorrect(""));
        }
        [TestMethod()]
        public void InputORFormatErrorTest()
        {
            Assert.AreEqual("ControlText", _model.InputORFormatError("1231"));
            Assert.AreEqual("Red", _model.InputORFormatError(""));
            Assert.AreEqual("Red", _model.InputORFormatError("asd0491"));
        }
        [TestMethod()]
        public void CheckColorStateTest()
        {
            Assert.AreEqual(false, _model.CheckColorState("Red"));
            Assert.AreEqual(true, _model.CheckColorState("ControlText"));
        }
        [TestMethod()]
        public void CheckAllStateTest()
        {
            Assert.AreEqual(true, _model.CheckAllState(true, true, true, true, true, true));
            Assert.AreEqual(false, _model.CheckAllState(true, true, false, true, true, true));
            Assert.AreEqual(false, _model.CheckAllState(true, true, true, true, false, true));
            Assert.AreEqual(false, _model.CheckAllState(true, false, true, false, true, true));
            Assert.AreEqual(false, _model.CheckAllState(false, false, true, false, false, true));
            Assert.AreEqual(false, _model.CheckAllState(true, false, false, false, true, false));
            Assert.AreEqual(false, _model.CheckAllState(false, false, false, false, false, false));
        }
        [TestMethod()]
        public void SetDrawStateTest()
        {
            _model.SetDrawState("UsingStart");
            _model.PointerDown(0, 0);
            _model.PointerMoved(13, 26);
            _model.PointerUp(55, 33);
            Assert.AreEqual("Start", _model.GetShapes()[0]._ShapeName);
            Assert.AreEqual(0, _model.GetShapes()[0]._ShapeY);
            Assert.AreEqual(0, _model.GetShapes()[0]._ShapeX);
            Assert.AreEqual(55, _model.GetShapes()[0]._ShapeWidth);
            Assert.AreEqual(33, _model.GetShapes()[0]._ShapeHeight);

            _model.SetDrawState("UsingTerminator");
            _model.PointerDown(0, 0);
            _model.PointerMoved(13, 26);
            _model.PointerUp(55, 33);
            Assert.AreEqual("Terminator", _model.GetShapes()[1]._ShapeName);
            Assert.AreEqual(0, _model.GetShapes()[1]._ShapeY);
            Assert.AreEqual(0, _model.GetShapes()[1]._ShapeX);
            Assert.AreEqual(55, _model.GetShapes()[1]._ShapeWidth);
            Assert.AreEqual(33, _model.GetShapes()[1]._ShapeHeight);

            _model.SetDrawState("UsingProcess");
            _model.PointerDown(0, 0);
            _model.PointerMoved(13, 26);
            _model.PointerUp(55, 33);
            Assert.AreEqual("Process", _model.GetShapes()[2]._ShapeName);
            Assert.AreEqual(0, _model.GetShapes()[2]._ShapeY);
            Assert.AreEqual(0, _model.GetShapes()[2]._ShapeX);
            Assert.AreEqual(55, _model.GetShapes()[2]._ShapeWidth);
            Assert.AreEqual(33, _model.GetShapes()[2]._ShapeHeight);

            _model.SetDrawState("UsingDecision");
            _model.PointerDown(0, 0);
            _model.PointerMoved(13, 26);
            _model.PointerUp(55, 33);
            Assert.AreEqual("Decision", _model.GetShapes()[3]._ShapeName);
            Assert.AreEqual(0, _model.GetShapes()[3]._ShapeY);
            Assert.AreEqual(0, _model.GetShapes()[3]._ShapeX);
            Assert.AreEqual(55, _model.GetShapes()[3]._ShapeWidth);
            Assert.AreEqual(33, _model.GetShapes()[3]._ShapeHeight);
        }
        [TestMethod()]
        public void ADDShapeFormDrawTest()
        {
            _model.SetDrawState("UsingProcess");
            _model.PointerDown(100, 100);
            _model.PointerMoved(100, 100);
            _model.PointerUp(100, 100);
            _model.NotifyModelChanged();
            Assert.AreEqual("Process", _model.GetShapes()[0]._ShapeName);
            Assert.AreEqual(100, _model.GetShapes()[0]._ShapeY);
            Assert.AreEqual(100, _model.GetShapes()[0]._ShapeX);
            Assert.AreEqual(10, _model.GetShapes()[0]._ShapeWidth);
            Assert.AreEqual(10, _model.GetShapes()[0]._ShapeHeight);
        }
        [TestMethod()]
        public void DrawTest()
        {
            _model.SetDrawState("UsingProcess");
            _model.PointerDown(100, 100);
            _model.PointerMoved(100, 100);
            _model.PointerUp(100, 100);
            Assert.AreEqual("Process", _model.GetShapes()[0]._ShapeName);
            Assert.AreEqual(100, _model.GetShapes()[0]._ShapeY);
            Assert.AreEqual(100, _model.GetShapes()[0]._ShapeX);
            Assert.AreEqual(10, _model.GetShapes()[0]._ShapeWidth);
            Assert.AreEqual(10, _model.GetShapes()[0]._ShapeHeight);
        }

        [TestMethod()]
        public void NotifyModelChangedTest()
        {
            Assert.IsFalse(_NotifyModel);
            _model.NotifyModelChanged();
            Assert.IsFalse(_NotifyModel);
            _model.modelChanged += () => { _NotifyModel = true; };
            _model.NotifyModelChanged();
            Assert.IsTrue(_NotifyModel);
        }


        [TestMethod()]
        public void PointTest()
        {
            _model.PointerDown(-10, 50);
            _model.PointerMoved(100, 100);
            _model.PointerUp(100, 100);
            _model.SetDrawState("Start");
            _model.PointerDown(0, 0);
            _model.PointerMoved(100, 100);
            _model.PointerUp(100, 100);
            _model.SetDrawState("Terminator");
            _model.PointerDown(0, 0);
            _model.PointerMoved(100, 100);
            _model.PointerUp(100, 100);
            _model.SetDrawState("Process");
            _model.PointerDown(0, 0);
            _model.PointerMoved(100, 100);
            _model.PointerUp(100, 100);
            _model.SetDrawState("Decision");
            _model.PointerDown(0, 0);
            _model.PointerMoved(100, 100);
            _model.PointerUp(100, 100);
            _model.SetPointState();
            _model.PointerDown(50, 50);
            _model.PointerMoved(100, 100);
            _model.PointerUp(100, 100);
            Assert.AreEqual(50, _model.GetShapes()[3]._ShapeX);
            Assert.AreEqual(50, _model.GetShapes()[3]._ShapeY);
        }

        [TestMethod()]
        public void DraingTest()
        {
            List<string> _task = new List<string>();
            IGraphics graphics = new MockGraphic(_task);
            _model.AddShape("Start", "0", "0", "0", "100", "100");
            _model.AddShape("Terminator", "0", "0", "150", "100", "100");
            _model.AddShape("Process", "0", "0", "300", "100", "100");
            _model.AddShape("Decision", "0", "0", "300", "100", "100");
            _model.PointerDown(0, 50);
            _model.PointerMoved(0, 60);
            _model.Draw(graphics);
            _model.PointerUp(0, 60);
            _model.PointerDown(0, 200);
            _model.PointerMoved(0, 210);
            _model.Draw(graphics);
            _model.PointerUp(0, 210);
            _model.PointerDown(0, 350);
            _model.PointerMoved(0, 360);
            _model.Draw(graphics);
            _model.PointerUp(0, 360);
            _model.PointerDown(0, 500);
            _model.PointerMoved(0, 510);
            _model.Draw(graphics);
            _model.PointerUp(0, 510);
            _model.SetDrawState("Start");
            _model.PointerDown(0, 750);
            _model.PointerMoved(0, 510);
            _model.Draw(graphics);
            _model.PointerUp(0, 1000);
        }
        [TestMethod()]
        public void CheckTest()
        {
            _model.SetDrawState("UsingProcess");
            _model.PointerDown(50, 50);
            _model.PointerMoved(100, 100);
            _model.PointerUp(100, 100);
            float x = (float)(_model.GetShapes()[0]._TextX + _model.GetShapes()[0]._ShapeX + _model.GetShapes()[0]._ShapeWidth / 2.5) + (float)(_model.GetShapes()[0]._ShapeText.Length * 2.48) + 3;
            float y = (float)(_model.GetShapes()[0]._TextY + _model.GetShapes()[0]._ShapeY + _model.GetShapes()[0]._ShapeHeight / 2.5) - 10 + 3;
            _model.SetPointState();
            _model.PointerDown(x, y);
            _model.PointerMoved(x, y);
            _model.PointerUp(x, y);
            _model.SetPointState();
            _model.PointerDown(x, y);
            _model.PointerMoved(x - 10, y - 10);
            _model.PointerUp(x - 20, y - 20);
            Assert.AreEqual(-20, _model.GetShapes()[0]._TextX);
            Assert.AreEqual(-20, _model.GetShapes()[0]._TextY);
        }
        [TestMethod()]
        public void CheckMouseInCricleTest()
        {
            _model.ADDShapeFormDrawState(new Start("123", 0, 0, 100, 100));
            _model.selectshape = _model.GetShapes()[0];
            float x = (float)(_model.selectshape._TextX + _model.selectshape._ShapeX + _model.selectshape._ShapeWidth / 2.5) + (float)(_model.selectshape._ShapeText.Length * 2.48);
            float y = (float)(_model.selectshape._TextY + _model.selectshape._ShapeY + _model.selectshape._ShapeHeight / 2.5) - 10;
            Assert.AreEqual(true, _model.CheckMouseInCricle((int)x + 5, (int)y + 5));
            Assert.AreEqual(false, _model.CheckMouseInCricle(0, 0));
        }
        [TestMethod()]
        public void DrawLineStateTest()
        {
            List<string> _task = new List<string>();
            IGraphics graphics = new MockGraphic(_task);
            _model.ADDShapeFormDrawState(new Start("123", 0, 0, 100, 100));
            _model.SetDrawLineState();
            _model.PointerDown(50, 0);
            _model.PointerMoved(50, 50);
            _model.Draw(graphics);
            _model.PointerUp(0, 50);
            _model.Draw(graphics);
            Assert.AreEqual(1, _model.GetLines().Count);
            _model.SetDrawLineState();
            _model.PointerDown(0, 0);
            _model.PointerMoved(100, 100);
            _model.Draw(graphics);
            _model.PointerUp(130, 130);
            _model.Draw(graphics);
            Assert.AreEqual(1, _model.GetLines().Count);
            _model.SetDrawLineState();
            _model.PointerDown(50, 0);
            _model.PointerMoved(100, 100);
            _model.Draw(graphics);
            _model.PointerUp(130, 130);
            _model.Draw(graphics);
            Assert.AreEqual(1, _model.GetLines().Count);
            _model.SetDrawLineState();
            _model.PointerDown(50, 0);
            _model.PointerMoved(100, 100);
            _model.Draw(graphics);
            _model.PointerUp(50, 0);
            _model.Draw(graphics);
            Assert.AreEqual(1, _model.GetLines().Count);
        }
    }
}