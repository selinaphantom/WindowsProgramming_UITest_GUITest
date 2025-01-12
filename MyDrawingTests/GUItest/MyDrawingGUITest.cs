using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MyDrawingTests.GUItest.Tests
{
    public class MyDrawingGUITest
    {
        [TestClass]
        public class MainFormUITest
        {
            private Robot robot;
            private string targetAppPath;
            private const string APP_TITLE = "MyDrawing";

            [TestInitialize]
            public void Initialize()
            {
                var projectName = "MyDrawing";
                string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
                targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "MyDrawing.exe");
                robot = new Robot(targetAppPath, APP_TITLE);
            }

            [TestMethod] //完成繪圖
            public void DrawingTest()
            {
                //按鈕測試
                robot.ClickButton("UsingProcess");
                robot.ClickButton("UsingTerminator");
                robot.ClickButton("UsingStart");
                robot.ClickButton("UsingLine");
                robot.AssertChecked("UsingStart", false);
                robot.AssertChecked("UsingTerminator", false);
                robot.AssertChecked("UsingDecision", false);
                robot.AssertChecked("UsingProcess", false);
                robot.AssertChecked("UsingLine", true);
                //繪圖測試
                robot.ClickButton("UsingStart");
                robot.MouseAction("Canvas", 20, 20, 100, 100);
                robot.ClickButton("UsingTerminator");
                robot.MouseAction("Canvas", 150, 20, 100, 100);
                robot.ClickButton("UsingDecision");
                robot.MouseAction("Canvas", 20, 150, 100, 100);
                robot.ClickButton("UsingProcess");
                robot.MouseAction("Canvas", 150, 150, 100, 100);
                robot.ClickButton("UsingLine");
                robot.MouseAction("Canvas", 75, 150, 0, 125);
                robot.AssertDataGridViewRowCountBy("_DataView", 5);
                Thread.Sleep(100);
            }
            public void AddDataGridView(string shape, string text, string x, string y, string w, string h)
            {
                robot.ComboBoxSelect("_ChooseType", shape);
                robot.SetBoxValue("_InputText", text);
                robot.SetBoxValue("_InputX", (int.Parse(x)).ToString());
                robot.SetBoxValue("_InputY", (int.Parse(y)).ToString());
                robot.SetBoxValue("_InputH", (int.Parse(h)).ToString());
                robot.SetBoxValue("_InputW", (int.Parse(w)).ToString());
                robot.ClickButton("新增");

            }
            [TestMethod]//完成Undo and Redo
            public void RedoaAndUndoTest()
            {
                robot.ClickButton("UsingStart");
                robot.MouseAction("Canvas", 100, 100, 100, 100);
                Thread.Sleep(100);
                robot.ClickButton("UsingTerminator");
                robot.MouseAction("Canvas", 300, 100, 100, 100);
                Thread.Sleep(100);
                robot.ClickButton("UsingDecision");
                robot.MouseAction("Canvas", 100, 300, 100, 100);
                Thread.Sleep(100);
                robot.ClickButton("UsingProcess");
                robot.MouseAction("Canvas", 300, 300, 100, 100);
                Thread.Sleep(100);
                robot.ClickButton("UsingLine");
                robot.MouseAction("Canvas", 150, 300, 0, 200);
                Thread.Sleep(100);
                robot.ClickButton("Undo");
                robot.ClickButton("Undo");
                robot.AssertEnable("Undo", true);
                robot.ClickButton("Undo");
                robot.ClickButton("Undo");
                robot.ClickButton("Undo");
                robot.ClickButton("Undo");
                robot.ClickButton("Undo");
                robot.AssertEnable("Undo", false);
                robot.ClickButton("Redo");
                robot.AssertEnable("Redo", true);
                robot.ClickButton("Redo");
                robot.ClickButton("Redo");
                robot.ClickButton("Redo");
                robot.ClickButton("Redo");
                robot.ClickButton("Redo");
                robot.ClickButton("Redo");
                robot.AssertEnable("Redo", false);
                robot.AssertDataGridViewRowCountBy("_DataView", 2);
                Thread.Sleep(2000);
            }
            [TestMethod]//完成透過DataGridView 新增刪除圖形
            public void DataGridViewTest()
            {
                AddDataGridView("Terminator", "1", "100", "100", "100", "100");
                AddDataGridView("Start", "2", "300", "100", "100", "100");
                AddDataGridView("Decision", "3", "100", "300", "100", "100");
                AddDataGridView("Process", "4", "300", "300", "100", "100");
                robot.AssertDataGridViewRowDataBy("_DataView", 0, "Terminator", 100, 100, 100, 100);
                robot.AssertDataGridViewRowDataBy("_DataView", 1, "Start", 300, 100, 100, 100);
                robot.AssertDataGridViewRowDataBy("_DataView", 2, "Decision", 100, 300, 100, 100);
                robot.AssertDataGridViewRowDataBy("_DataView", 3, "Process", 300, 300, 100, 100);
                robot.ClickDataGridViewCellBy("_DataView", 0, "刪");
                Thread.Sleep(200);
                robot.ClickDataGridViewCellBy("_DataView", 0, "刪");
                Thread.Sleep(200);
                robot.ClickDataGridViewCellBy("_DataView", 0, "刪");
                Thread.Sleep(200);
                robot.ClickDataGridViewCellBy("_DataView", 0, "刪");
            }
            public void DrawingShape(string shape, int x, int y, int moveX, int moveY)
            {
                robot.ClickButton(shape);
                robot.MouseAction("Canvas", x, y, moveX, moveY);
                Thread.Sleep(100);

            }
            [TestMethod]//完成拖曳圖形
            public void MoveShape()
            {

                DrawingShape("UsingStart", 100, 100, 100, 100);
                DrawingShape("UsingTerminator", 300, 100, 100, 100);
                DrawingShape("UsingDecision", 100, 300, 100, 100);
                DrawingShape("UsingProcess", 300, 300, 100, 100);
                DrawingShape("UsingLine", 150, 300, 0, 200);

                robot.MouseAction("Canvas", 150, 150, 0, 100);
                Thread.Sleep(200);
                robot.MouseAction("Canvas", 350, 350, 100, 100);
                Thread.Sleep(200);
                robot.MouseAction("Canvas", 150, 350, 100, 0);
                Thread.Sleep(200);
                robot.MouseAction("Canvas", 350, 150, 0, 100);
                Thread.Sleep(200);
                Thread.Sleep(2000);
            }
            [TestMethod]//完成拖曳文字
            public void MoveTextTest()
            {
                AddDataGridView("Start", "123", "100", "100", "100", "100");
                DrawingShape("UsingTerminator", 300, 100, 100, 100);
                DrawingShape("UsingDecision", 100, 300, 100, 100);
                DrawingShape("UsingProcess", 300, 300, 100, 100);
                robot.MouseAction("Canvas", 125, 110, 0, 0);
                Thread.Sleep(200);
                robot.MouseAction("Canvas", 125, 110, 0, 100);
                Thread.Sleep(2000);
                robot.AssertDataGridViewRowDataBy("_DataView", 0, "Start", 100, 100, 100, 100);
                Thread.Sleep(200);
            }

            [TestMethod]//完成修改文字
            public void EditTextTest()
            {
                AddDataGridView("Start", "123", "100", "100", "100", "100");
                DrawingShape("UsingTerminator", 300, 100, 100, 100);
                DrawingShape("UsingDecision", 100, 300, 100, 100);
                DrawingShape("UsingProcess", 300, 300, 100, 100);
                robot.MouseAction("Canvas", 125, 110, 0, 0);
                robot.MouseAction("Canvas", 125, 110, 0, 0);
                robot.SetBoxValue("EditText", "100");
                robot.ClickButton("確認");
                robot.AssertDataGridViewRowDataByText("_DataView", 0, "100");
                Thread.Sleep(100);
            }



            [TestMethod] //完成Save & Load
            public void SaveAndLoadTest()
            {
                AddDataGridView("Terminator", "1", "100", "100", "100", "100");
                AddDataGridView("Start", "2", "300", "100", "100", "100");
                robot.ClickButton("Save");
                Thread.Sleep(100);
                robot.SetText("", "GUI測試");
                robot.ClickButton("存檔(S)");
                robot.AssertEnable("Save", false);
                AddDataGridView("Decision", "3", "100", "300", "100", "100");
                AddDataGridView("Process", "4", "300", "300", "100", "100");
                robot.AssertEnable("Save", true);
                robot.ClickButton("Load");
                Thread.Sleep(100);
                robot.ClickButton("GUI測試.mydrawing");
                robot.ClickButton("開啟(O)");
                robot.AssertDataGridViewRowCountBy("_DataView", 4);
                robot.AssertDataGridViewRowDataBy("_DataView", 0, "Terminator", 100, 100, 100, 100);
                robot.AssertDataGridViewRowDataBy("_DataView", 1, "Start", 300, 100, 100, 100);
                Thread.Sleep(100);
            }

            [TestMethod] //完成Auto save
            public void AutoSaveTest()
            {
                // 固定路徑
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string folderName = "drawing_backup";
                string folderPath = Path.Combine(basePath, folderName);

                // 模擬操作
                DrawingShape("UsingStart", 20, 20, 100, 100);
                DrawingShape("UsingTerminator", 150, 20, 100, 100);
                DrawingShape("UsingDecision", 20, 150, 100, 100);
                DrawingShape("UsingProcess", 150, 150, 100, 100);
                Thread.Sleep(25000);
                AddDataGridView("Terminator", "1", "100", "100", "100", "100");
                // 等待一段時間確保自動存檔操作完成
                Thread.Sleep(3500);
                robot.AssertDataGridViewRowDataBy("_DataView", 4, "Terminator", 100, 100, 100, 100);
            }

            [TestMethod]
            public void ALLTest()
            {
                AddDataGridView("Start", "起床", "250", "40", "170", "70");
                AddDataGridView("Process", "吃早餐", "250", "130", "170", "70");
                AddDataGridView("Process", "寫程式", "250", "230", "170", "70");
                AddDataGridView("Decision", "BUG解決", "265", "340", "120", "70");
                AddDataGridView("Process", "失敗", "470", "350", "170", "70");
                AddDataGridView("Process", "抓狂", "470", "230", "170", "70");
                AddDataGridView("Process", "成功", "40", "350", "170", "70");
                AddDataGridView("Terminator", "傳作業+開心", "40", "460", "160", "70");
                DrawingShape("UsingLine", 268, 85, 20, 0);
                DrawingShape("UsingLine", 268, 165, 20, 0);
                DrawingShape("UsingLine", 268, 240, 31, -6);
                DrawingShape("UsingLine", 306, 303, 3, 74);
                DrawingShape("UsingLine", 442, 283, -40, 0);
                DrawingShape("UsingLine", 375, 213, 0, -35);
                DrawingShape("UsingLine", 217, 302, 5, -51);
                DrawingShape("UsingLine", 100, 335, 37, 0);

                AddDataGridView("Start", "123", "20", "20", "100", "100");
                robot.MouseAction("Canvas", 45, 40, 0, 0);
                Thread.Sleep(100);
                robot.MouseAction("Canvas", 56, 45, 0, 0);
                robot.MouseAction("Canvas", 56, 45, 0, 0);
                robot.SetBoxValue("EditText", "我花了兩天DeBug");
                robot.ClickButton("確認");
                Thread.Sleep(100);
                robot.ClickButton("Save");
                Thread.Sleep(100);
                robot.SetText("", "整合測試");
                robot.ClickButton("存檔(S)");
                Thread.Sleep(2000);
                // 等待一段時間確保自動存檔操作完成
            }
            [TestCleanup()]
            public void Cleanup()
            {
                robot.CleanUp();
            }

        }
    }
}
