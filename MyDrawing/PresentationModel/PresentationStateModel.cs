using MyDrawing.Command;
using MyDrawing.Shape;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Timers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Remoting.Messaging;
using System.IO;
using static System.Windows.Forms.LinkLabel;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace MyDrawing
{
    public class PresentationStateModel : INotifyPropertyChanged  //控制在View會用到的Toolbar狀態。
    {
        public event PropertyChangedEventHandler PropertyChanged;
        bool _AddShapeEnabled = false;//DataBinding的對應狀態。
        //工具選擇的狀態。
        private bool _CurrentState = false;//false:一般模式;true:繪圖模式。
        private bool _StartChecked = false;
        private bool _TerminatorChecked = false;
        private bool _ProcessChecked = false;
        private bool _DecisionChecked = false;
        private bool _LineChecked;
        //輸入內容的判斷狀態
        private bool _ChooseState = false;
        private bool _TextState = false;
        private bool _XState = false;
        private bool _YState = false;
        private bool _WidthState = false;
        private bool _HeightState = false;
        //文字目前的顏色
        private string _Textcolor = "Red";
        private string _Xcolor = "Red";
        private string _Ycolor = "Red";
        private string _Widthcolor = "Red";
        private string _Heightcolor = "Red";
        //資料的長度
        public int _DataSize { set; get; }


        public void checkfilenum(string backupFolder)
        {
            var files = Directory.GetFiles(backupFolder, "*");

            if (files.Length > 5)
            {
                var fileToDelete = files
                    .OrderBy(f => Path.GetFileNameWithoutExtension(f))
                    .First();
                File.Delete(fileToDelete);
            }
        }

        public async Task SaveShapesAsync(Model model, string filePath)
        {
            await Task.Run(() =>
            {

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var shpae in model._Shapes.shapes)
                    {
                        writer.WriteLine($"{"Shape"}," +
                                            $"{shpae._ShapeName}," +
                                            $"{shpae._ShapeText}," +
                                            $"{shpae._ShapeX}," +
                                            $"{shpae._ShapeY}," +
                                            $"{shpae._ShapeHeight}," +
                                            $"{shpae._ShapeWidth},");

                    }
                    foreach (var line in model._Lines)
                    {
                        writer.WriteLine($"{"Line"}," +
                                            $"{line.FristShape._ShapeName}," +
                                            $"{line.FristShape._ShapeText}," +
                                            $"{line.FristShape._ShapeX}," +
                                            $"{line.FristShape._ShapeY}," +
                                            $"{line.FinalShape._ShapeName}," +
                                            $"{line.FinalShape._ShapeText}," +
                                            $"{line.FinalShape._ShapeX}," +
                                            $"{line.FinalShape._ShapeY}," +
                                            $"{line.FristPoint}," +
                                            $"{line.FinalPoint}," +
                                            $"{line.FristX}," +
                                            $"{line.FristY}," +
                                            $"{line.FinalX}," +
                                            $"{line.FinalY}");
                    }
                }
                Thread.Sleep(3000);
            });
        }

        public void LoadShapes(Model model, string filePath)
        {
            string json = File.ReadAllText(filePath);
            var jsonData = File.ReadAllText(filePath);
            model._Shapes.shapes.Clear();
            model._Lines.Clear();
            model.selectshape = null;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string lineText;
                while ((lineText = reader.ReadLine()) != null)
                {
                    // 分割每一行的資料
                    var data = lineText.Split(','); // 使用逗號分隔每個屬性
                    if (data[0] == "Shape")
                    {
                        model.AddShape("Using" + data[1], data[2], data[3], data[4], data[5], data[6]);
                    }
                    if (data[0] == "Line")
                    {
                        Line line = new Line();
                        foreach (IShape shape in Enumerable.Reverse(model.GetShapes()))
                        {
                            if (shape._ShapeName == data[1] && shape._ShapeText == data[2] && shape._ShapeX == double.Parse(data[3]) && shape._ShapeY == double.Parse(data[4]))
                            {
                                line.FristShape = shape;
                            }
                            if (shape._ShapeName == data[5] && shape._ShapeText == data[6] && shape._ShapeX == double.Parse(data[7]) && shape._ShapeY == double.Parse(data[8]))
                            {
                                line.FinalShape = shape;
                            }
                        }

                        line.FristPoint = data[9];
                        line.FinalPoint = data[10];
                        line.FristX = double.Parse(data[11]);
                        line.FristY = double.Parse(data[12]);
                        line.FinalX = double.Parse(data[13]);
                        line.FinalY = double.Parse(data[14]);
                        model.AddLine(line);
                    }
                }
            }
            model.NotifyModelChanged();
            model.commands.ClearALL();
        }

        public void ButtonChecked(Model model, string ButtonType = "Reset")
        {
            ResetAllState();
            if (ButtonType == "UsingStart")
            {
                _StartChecked = true;
                _CurrentState = true;
                model.SetDrawState(ButtonType);
            }
            else if (ButtonType == "UsingTerminator")
            {
                _TerminatorChecked = true;
                _CurrentState = true;
                model.SetDrawState(ButtonType);
            }
            else if (ButtonType == "UsingProcess")
            {
                _ProcessChecked = true;
                _CurrentState = true;
                model.SetDrawState(ButtonType);
            }
            else if (ButtonType == "UsingDecision")
            {
                _DecisionChecked = true;
                _CurrentState = true;
                model.SetDrawState(ButtonType);
            }
            else if (ButtonType == "UsingLine")
            {
                _LineChecked = true;
                _CurrentState = true;
                model.SetDrawLineState();
            }
            else
            {
                _CurrentState = false;
                model.SetPointState();
            }
            _AddShapeEnabled = model.CheckAllState(_ChooseState, _TextState, _XState, _YState, _WidthState, _HeightState);
            NotifyPropertyChanged("AddShapeEnabled");
        }
        public void DataViewDelClick(Model model, int CheckIndex, int DelIndex, int DataIndex)//刪除資料欄的對應資料。
        {
            if (CheckIndex == DelIndex && DataIndex >= 0 && DataIndex < _DataSize)
            {
                for (int i = model.GetLines().Count - 1; i >= 0; i--)
                {
                    if (model.GetLines()[i].FristShape == model.GetShapes()[DataIndex] || model.GetLines()[i].FinalShape == model.GetShapes()[DataIndex])
                        model.AddCommand(new DeleteLineCommand(model, model.GetLines()[i], i));
                }
                model.AddCommand(new DeleteCommand(model, model.GetShapes()[DataIndex], DataIndex));
            }
            else if (CheckIndex == DelIndex && DataIndex >= 0 && DataIndex >= _DataSize)
            {
                model.AddCommand(new DeleteLineCommand(model, model.GetLines()[DataIndex - _DataSize], DataIndex - _DataSize));
            }
        }

        public void CheckError(int Index, string Text, string X, string Y, string Height, string Width, Model model)//檢查錯誤。
        {
            _ChooseState = model.CheckChooseStateCorrect(Index);
            _Textcolor = model.CheckTextCorrect(Text);
            _Xcolor = model.InputORFormatError(X);
            _Ycolor = model.InputORFormatError(Y);
            _Heightcolor = model.InputORFormatError(Height);
            _Widthcolor = model.InputORFormatError(Width);
            _TextState = model.CheckColorState(_Textcolor);
            _XState = model.CheckColorState(_Xcolor);
            _YState = model.CheckColorState(_Ycolor);
            _WidthState = model.CheckColorState(_Heightcolor);
            _HeightState = model.CheckColorState(_Widthcolor);
            _AddShapeEnabled = model.CheckAllState(_ChooseState, _TextState, _XState, _YState, _WidthState, _HeightState);
            NotifyPropertyChanged("AddShapeEnabled");
        }

        private void ResetAllState()//重製工具欄的狀態。
        {
            _StartChecked = false;
            _TerminatorChecked = false;
            _ProcessChecked = false;
            _DecisionChecked = false;
            _LineChecked = false;
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Textcolor
        {
            get { return _Textcolor; }
        }
        public string Xcolor
        {
            get { return _Xcolor; }
        }
        public string Ycolor
        {
            get { return _Ycolor; }
        }
        public string Widthcolor
        {
            get { return _Widthcolor; }
        }
        public string Heightcolor
        {
            get { return _Heightcolor; }
        }
        public bool AddShapeEnabled
        {
            get { return _AddShapeEnabled; }
        }
        public bool StartState
        {
            get { return _StartChecked; }
        }
        public bool TerminatorState
        {
            get { return _TerminatorChecked; }
        }
        public bool ProcessState
        {
            get { return _ProcessChecked; }
        }
        public bool DecisionState
        {
            get { return _DecisionChecked; }
        }
        public bool LineState
        {
            get { return _LineChecked; }
        }
        public bool CurrentState
        {
            get { return _CurrentState; }
        }
    }
}
