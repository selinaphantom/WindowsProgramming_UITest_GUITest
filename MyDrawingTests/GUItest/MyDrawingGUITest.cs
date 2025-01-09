using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            //[TestMethod] //完成
            //public void DrawingTest()
            //{
            //    //按鈕測試
            //    robot.ClickButton("Process");
            //    robot.ClickButton("Terminator");
            //    robot.ClickButton("Start");
            //    robot.ClickButton("Line");
            //    robot.AssertChecked("Start", false);
            //    robot.AssertChecked("Terminator", false);
            //    robot.AssertChecked("Decision", false);
            //    robot.AssertChecked("Process", false);
            //    robot.AssertChecked("Line", true);
            //    //繪圖測試
            //    robot.ClickButton("Start");
            //    robot.MouseAction("Canvas", 20, 20, 100, 100);
            //    robot.ClickButton("Terminator");
            //    robot.MouseAction("Canvas", 150, 20, 100, 100);
            //    robot.ClickButton("Decision");
            //    robot.MouseAction("Canvas", 20, 150, 100, 100);
            //    robot.ClickButton("Process");
            //    robot.MouseAction("Canvas", 150, 150, 100, 100);
            //    robot.ClickButton("Line");
            //    robot.MouseAction("Canvas", 75, 150, 0, 125);
            //    robot.ClickButton("Line");
            //    robot.MouseAction("Canvas", 65, 20, 135, 135);
            //    robot.AssertDataGridViewRowCountBy("_DataView", 6);
            //    Thread.Sleep(100);
            //}

            //[TestMethod]//完成
            //public void RedoaAndUndoTest()
            //{
            //    robot.ClickButton("Start");
            //    robot.MouseAction("Canvas", 20, 20, 100, 100);
            //    robot.ClickButton("Terminator");
            //    robot.MouseAction("Canvas", 150, 20, 100, 100);
            //    robot.ClickButton("Decision");
            //    robot.MouseAction("Canvas", 20, 150, 100, 100);
            //    robot.ClickButton("Process");
            //    robot.MouseAction("Canvas", 150, 150, 100, 100);
            //    robot.ClickButton("Line");
            //    robot.MouseAction("Canvas", 75, 150, 0, 125);
            //    robot.ClickButton("Line");
            //    robot.MouseAction("Canvas", 65, 20, 135, 135);
            //    Thread.Sleep(200);
            //    robot.MouseAction("Canvas", 150, 150, 100, 100);
            //    Thread.Sleep(200);
            //    robot.MouseAction("Canvas", 60, 60, 0, 150);
            //    Thread.Sleep(200);
            //    robot.MouseAction("Canvas", 0, 0, 0, 0);
            //    Thread.Sleep(200);
            //    robot.MouseAction("Canvas", 175, 75, 25, -150);
            //    Thread.Sleep(200);
            //    robot.ClickButton("Undo");
            //    robot.ClickButton("Undo");
            //    robot.AssertEnable("Undo", true);
            //    robot.ClickButton("Undo");
            //    robot.ClickButton("Undo");
            //    robot.ClickButton("Undo");
            //    robot.ClickButton("Undo");
            //    robot.ClickButton("Undo");
            //    robot.ClickButton("Undo");
            //    robot.ClickButton("Undo");
            //    robot.ClickButton("Undo");
            //    robot.AssertEnable("Undo", false);
            //    robot.ClickButton("Redo");
            //    robot.AssertEnable("Redo", true);
            //    robot.ClickButton("Redo");
            //    robot.ClickButton("Redo");
            //    robot.ClickButton("Redo");
            //    robot.ClickButton("Redo");
            //    robot.ClickButton("Redo");
            //    robot.ClickButton("Redo");
            //    robot.ClickButton("Redo");
            //    robot.ClickButton("Redo");
            //    robot.ClickButton("Redo");
            //    robot.AssertEnable("Redo", false);
            //    robot.AssertDataGridViewRowCountBy("_DataView", 2);
            //    Thread.Sleep(100);
            //}
            //[TestMethod]//完成
            //public void DataGridViewTest()
            //{
            //    robot.SetText("_InputText", "123");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputX", "20");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputY", "12s3");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputH", "100");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputY", "20");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputW", "100");
            //    Thread.Sleep(200);
            //    robot.MouseAction("_DataDisplay", 100, 40, 0, 0);
            //    robot.MouseAction("_DataDisplay", 100, 70, 0, 0);
            //    robot.ClickButton("新增");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 0, 3, "Start");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 0, 5, "20");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 0, 6, "20");

            //    robot.SetText("_InputText", "123");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputX", "150");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputY", "20");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputH", "100");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputW", "100");
            //    Thread.Sleep(200);
            //    robot.MouseAction("_DataDisplay", 100, 40, 0, 0);
            //    robot.MouseAction("_DataDisplay", 100, 80, 0, 0);
            //    robot.ClickButton("新增");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 1, 3, "Terminator");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 1, 5, "150");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 1, 6, "20");

            //    robot.SetText("_InputText", "123");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputX", "20");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputY", "150");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputH", "100");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputW", "100");
            //    Thread.Sleep(200);
            //    robot.MouseAction("_DataDisplay", 100, 40, 0, 0);
            //    robot.MouseAction("_DataDisplay", 100, 90, 0, 0);
            //    robot.ClickButton("新增");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 2, 3, "Process");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 2, 5, "20");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 2, 6, "150");

            //    robot.SetText("_InputText", "123");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputX", "150");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputY", "150");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputH", "100");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputW", "100");
            //    Thread.Sleep(200);
            //    robot.MouseAction("_DataDisplay", 100, 40, 0, 0);
            //    robot.MouseAction("_DataDisplay", 100, 100, 0, 0);
            //    robot.ClickButton("新增");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 3, 3, "Decision");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 3, 5, "150");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 3, 6, "150");

            //    robot.MouseAction("_DataView", 20, 40, 0, 0);
            //    Thread.Sleep(200);
            //    robot.MouseAction("_DataView", 20, 40, 0, 0);
            //    Thread.Sleep(200);
            //    robot.MouseAction("_DataView", 20, 40, 0, 0);
            //    Thread.Sleep(200);
            //    robot.MouseAction("_DataView", 20, 40, 0, 0);
            //    Thread.Sleep(100);
            //}

            //[TestMethod]//完成
            //public void MoveShape()
            //{
            //    robot.ClickButton("Start");
            //    robot.MouseAction("Canvas", 20, 20, 100, 100);
            //    robot.ClickButton("Terminator");
            //    robot.MouseAction("Canvas", 150, 20, 100, 100);
            //    robot.ClickButton("Decision");
            //    robot.MouseAction("Canvas", 20, 150, 100, 100);
            //    robot.ClickButton("Process");
            //    robot.MouseAction("Canvas", 150, 150, 100, 100);
            //    robot.ClickButton("Line");
            //    robot.MouseAction("Canvas", 75, 150, 0, 125);
            //    robot.ClickButton("Line");
            //    robot.MouseAction("Canvas", 65, 20, 135, 135);
            //    Thread.Sleep(200);
            //    robot.MouseAction("Canvas", 150, 150, 100, 100);
            //    Thread.Sleep(200);
            //    robot.MouseAction("Canvas", 60, 60, 0, 150);
            //    Thread.Sleep(200);
            //    robot.MouseAction("Canvas", 0, 0, 0, 0);
            //    Thread.Sleep(200);
            //    robot.MouseAction("Canvas", 175, 75, 25, -150);
            //    Thread.Sleep(200);
            //    robot.AssertDataGridViewRowDataBy("_DataView", 1, 7, "100");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 1, 6, "45");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 5, 5, "220");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 5, 6, "20");
            //    Thread.Sleep(100);
            //}
            //[TestMethod]//完成
            //public void MoveTextTest()
            //{
            //    robot.SetText("_InputText", "123");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputX", "20");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputY", "12s3");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputH", "100");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputY", "20");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputW", "100");
            //    Thread.Sleep(200);
            //    robot.MouseAction("_DataDisplay", 100, 40, 0, 0);
            //    robot.MouseAction("_DataDisplay", 100, 70, 0, 0);
            //    robot.ClickButton("新增");
            //    robot.ClickButton("Terminator");
            //    robot.MouseAction("Canvas", 150, 20, 100, 100);
            //    robot.ClickButton("Decision");
            //    robot.MouseAction("Canvas", 20, 150, 100, 100);
            //    robot.ClickButton("Process");
            //    robot.MouseAction("Canvas", 150, 150, 100, 100);
            //    robot.MouseAction("Canvas", 76, 56, 200, 23);
            //    robot.AssertDataGridViewRowDataBy("_DataView", 0, 4, "123");
            //    Thread.Sleep(100);
            //}

            //[TestMethod]//完成
            //public void EditTextTest()
            //{
            //    robot.SetText("_InputText", "123");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputX", "20");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputY", "12s3");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputH", "100");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputY", "20");
            //    Thread.Sleep(200);
            //    robot.SetText("_InputW", "100");
            //    Thread.Sleep(200);
            //    robot.MouseAction("_DataDisplay", 100, 40, 0, 0);
            //    robot.MouseAction("_DataDisplay", 100, 70, 0, 0);
            //    robot.ClickButton("新增");
            //    robot.ClickButton("Terminator");
            //    robot.MouseAction("Canvas", 150, 20, 100, 100);
            //    robot.ClickButton("Decision");
            //    robot.MouseAction("Canvas", 20, 150, 100, 100);
            //    robot.ClickButton("Process");
            //    robot.MouseAction("Canvas", 150, 150, 100, 100);
            //    robot.MouseAction("Canvas", 76, 56, 0, 0);
            //    robot.MouseAction("Canvas", 76, 56, 0, 0);
            //    robot.SetText("EditText", "100");
            //    robot.ClickButton("確認");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 0, 4, "100");
            //    Thread.Sleep(100);
            //}



            //[TestMethod] //完成
            //public void SaveAndLoadTest()
            //{
            //    robot.ClickButton("Start");
            //    robot.MouseAction("Canvas", 20, 20, 100, 100);
            //    robot.ClickButton("Terminator");
            //    robot.MouseAction("Canvas", 150, 20, 100, 100);
            //    robot.ClickButton("Save");
            //    robot.SetText("", "GUI測試");
            //    robot.ClickButton("存檔(S)");
            //    robot.AssertEnable("Save", false);
            //    robot.ClickButton("Decision");
            //    robot.MouseAction("Canvas", 20, 150, 100, 100);
            //    robot.ClickButton("Decision");
            //    robot.MouseAction("Canvas", 200, 200, 100, 100);
            //    robot.ClickButton("Process");
            //    robot.MouseAction("Canvas", 150, 150, 100, 100);
            //    robot.AssertEnable("Save", true);
            //    robot.ClickButton("Load");
            //    robot.ClickButton("GUI測試");
            //    robot.ClickButton("開啟(O)");
            //    robot.AssertDataGridViewRowCountBy("_DataView", 4);

            //    robot.AssertDataGridViewRowDataBy("_DataView", 0, 3, "Start");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 1, 3, "Terminator");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 2, 3, "Decision");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 3, 3, "Decision");

            //    robot.AssertDataGridViewRowDataBy("_DataView", 0, 5, "20");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 1, 5, "150");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 2, 5, "20");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 3, 5, "200");


            //    robot.AssertDataGridViewRowDataBy("_DataView", 0, 7, "100");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 1, 7, "100");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 2, 7, "100");
            //    robot.AssertDataGridViewRowDataBy("_DataView", 3, 7, "100");
            //    Thread.Sleep(100);
            //}

            [TestMethod]
            public async Task AutoSaveTest()
            {
                // 固定路徑
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string folderName = "drawing_backup";
                string folderPath = Path.Combine(basePath, folderName);

                // 確認資料夾存在
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    Console.WriteLine($"資料夾已建立：{folderPath}");
                }
                else
                {
                    Console.WriteLine($"資料夾已存在：{folderPath}");
                }

                // 模擬操作
                robot.ClickButton("Start");
                robot.MouseAction("Canvas", 20, 20, 100, 100);
                robot.ClickButton("Terminator");
                robot.MouseAction("Canvas", 150, 20, 100, 100);
                robot.ClickButton("Decision");
                robot.MouseAction("Canvas", 20, 150, 100, 100);
                robot.ClickButton("Decision");
                robot.MouseAction("Canvas", 200, 200, 100, 100);
                robot.ClickButton("Process");
                robot.MouseAction("Canvas", 150, 150, 100, 100);

                // 等待一段時間確保自動存檔操作完成
                robot.SwitchTo("MyDrawing");
                await Task.Delay(25000);
                // 檢查 backup 資料夾中的檔案數量
                string backupFolder = Path.Combine(basePath, "drawing_backup");

                //}
                //[TestMethod]
                //public void ALLTest()
                //{
                //    robot.SetText("_InputText", "123");
                //    Thread.Sleep(200);
                //    robot.SetText("_InputX", "20");
                //    Thread.Sleep(200);
                //    robot.SetText("_InputY", "12s3");
                //    Thread.Sleep(200);
                //    robot.SetText("_InputH", "100");
                //    Thread.Sleep(200);
                //    robot.SetText("_InputY", "20");
                //    Thread.Sleep(200);
                //    robot.SetText("_InputW", "100");
                //    Thread.Sleep(200);
                //    robot.MouseAction("_DataDisplay", 100, 40, 0, 0);
                //    robot.MouseAction("_DataDisplay", 100, 70, 0, 0);
                //    robot.ClickButton("新增");

                //    robot.SetText("_InputText", "123");
                //    Thread.Sleep(200);
                //    robot.SetText("_InputX", "150");
                //    Thread.Sleep(200);
                //    robot.SetText("_InputY", "20");
                //    Thread.Sleep(200);
                //    robot.SetText("_InputH", "100");
                //    Thread.Sleep(200);
                //    robot.SetText("_InputW", "100");
                //    Thread.Sleep(200);
                //    robot.MouseAction("_DataDisplay", 100, 40, 0, 0);
                //    robot.MouseAction("_DataDisplay", 100, 80, 0, 0);
                //    robot.ClickButton("新增");

                //    robot.SetText("_InputText", "123");
                //    Thread.Sleep(200);
                //    robot.SetText("_InputX", "20");
                //    Thread.Sleep(200);
                //    robot.SetText("_InputY", "150");
                //    Thread.Sleep(200);
                //    robot.SetText("_InputH", "100");
                //    Thread.Sleep(200);
                //    robot.SetText("_InputW", "100");
                //    Thread.Sleep(200);
                //    robot.MouseAction("_DataDisplay", 100, 40, 0, 0);
                //    robot.MouseAction("_DataDisplay", 100, 90, 0, 0);
                //    robot.ClickButton("新增");

                //    robot.SetText("_InputText", "123");
                //    Thread.Sleep(200);
                //    robot.SetText("_InputX", "150");
                //    Thread.Sleep(200);
                //    robot.SetText("_InputY", "150");
                //    Thread.Sleep(200);
                //    robot.SetText("_InputH", "100");
                //    Thread.Sleep(200);
                //    robot.SetText("_InputW", "100");
                //    Thread.Sleep(200);
                //    robot.MouseAction("_DataDisplay", 100, 40, 0, 0);
                //    robot.MouseAction("_DataDisplay", 100, 100, 0, 0);
                //    robot.ClickButton("新增");
                //    // 等待一段時間確保自動存檔操作完成
                //    robot.SwitchTo("MyDrawing");

                //}
                [TestCleanup()]
            public void Cleanup()
            {
                robot.CleanUp();
            }

        }
    }
}
