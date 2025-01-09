using MyDrawing.Command;
using MyDrawing.Shape;
using MyDrawing.State;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.LinkLabel;

namespace MyDrawing
{
    public class Model
    {
        public bool _modelChange { get; set; } = false;
        public CommandManager commands = new CommandManager();
        public Shapes _Shapes = new Shapes(); //建立Shapes。
        public List<Line> _Lines = new List<Line>();
        public readonly bool _UseState = false;
        public IShape shape;
        public IShape selectshape;
        public IShape Overshape;
        public Line drawingLine;
        public IState currentstate;
        public IState drawstate;
        public IState pointstate;
        public IState drawLinestate;
        public string _ShapeName;
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler modelChanged; //用事件的方式通知Model的資料有做更動。


        public Model()
        {
            this.drawstate = new DrawState(this);
            this.pointstate = new PointState(this);
            this.drawLinestate = new DrawLineState(this);
            this._UseState = true;
            SetPointState();
        }
        public void AddShape(string ChooseType, string InputText, string InputX, string InputY, string InputHeight, string InputWidth) //新增Shape。
        {
            _Shapes.CreateShape(ChooseType, InputText, InputX, InputY, InputHeight, InputWidth);
            NotifyModelChanged();
        }
        public void DeleteShape(int _Index) //刪除list中的Shape。
        {
            _Shapes.RemoveShape(_Index);
            selectshape = null;
            NotifyModelChanged();
        }
        public void DeleteLine(int _Index) //刪除list中的Shape。
        {
            _Lines.RemoveAt(_Index);
            NotifyModelChanged();
        }
        public void ModityText(IShape shape, string Text)//修改圖形文字。
        {
            shape._ShapeText = Text;
        }
        public bool CheckMouseInCricle(int x, int y)//確認是否有圖形被選中，以及圖形是否連點的位置在文字的修改點上。
        {
            if (selectshape != null && selectshape.IsMouseOverCircle(x, y))
                return true;
            return false;
        }
        public bool CheckChooseStateCorrect(int ChooseIndex)//確認下拉式選單是否有選擇。
        {
            if (ChooseIndex == -1)
            {
                return false;
            }
            return true;
        }
        public string CheckTextCorrect(string InputText)//確認文字是否有填入。
        {
            if (InputText == "")
            {
                return "Red";
            }
            return "ControlText";
        }

        public string InputORFormatError(string Inputdata) //簡化判斷時的重複程式。
        {
            if (Inputdata == "" || !double.TryParse(Inputdata, out _))
            {
                return "Red";
            }
            return "ControlText";
        }
        public bool CheckColorState(string ColorType)//判斷是否照格式輸入。
        {
            if (ColorType == "Red")
            {
                return false;
            }
            return true;
        }
        public bool CheckAllState(bool ChooseState, bool TextState, bool XState, bool YState, bool WidthState, bool HeightState)//檢查所有的狀態是否都輸入了。
        {
            if (ChooseState & TextState & XState & YState & WidthState & HeightState)
            {
                return true;
            }
            return false;
        }

        public List<IShape> GetShapes() //輸出目前的紀錄內容。
        {
            return _Shapes.GetAllShape();
        }
        public List<Line> GetLines() //輸出目前的紀錄內容。
        {
            return _Lines;
        }
        public bool GetCommandUndoState()//確認上一步命令欄是否到底了。
        {
            return commands.IsUndoEnabled;
        }
        public bool GetCommandRedoState()//確認下一步命令欄是否到底了。
        {
            return commands.IsRedoEnabled;
        }
        public void PointerDown(double x, double y)//紀錄最初的座標。
        {
            currentstate.MouseDown(x, y);
            NotifyModelChanged();
        }
        public void PointerMoved(double x, double y)//紀錄滑鼠的座標。
        {
            currentstate.MouseMove(x, y);
            NotifyModelChanged();
        }
        public void PointerUp(double x, double y)
        {
            currentstate.MouseUp(x, y);
            NotifyModelChanged();
        }
        public void ADDShapeFormDrawState(IShape shape)//儲存最終的圖形。
        {
            //避免圖形的Height或Width為零，因此參考powerpoint新增圖形的方法來解決這個問題。
            if (shape._ShapeWidth == 0)
            {
                shape._ShapeWidth = 10;
            }
            if (shape._ShapeHeight == 0)
            {
                shape._ShapeHeight = 10;
            }
            if (this.shape != null)
            {
                _Shapes.shapes.Add(this.shape);
                this.selectshape = this.shape;
                this.shape = null;
            }
            else
            {
                _Shapes.shapes.Add(shape);
                this.selectshape = shape;
            }
        }
        public void AddLine(Line line)//紀錄線的資料。
        {
            _Lines.Add(line);
        }
        public void Draw(IGraphics graphics)//畫出儲存的圖形，以及正在繪製的圖形。
        {
            graphics.ClearAll();
            foreach (IShape item in _Shapes.GetAllShape())
            {
                item.Draw(graphics);
            }
            if (this.shape != null)
                this.shape.Draw(graphics);
            if (this.selectshape != null)
                this.selectshape.DrawEdge(graphics);
            foreach (Line line in _Lines)
                line.Draw(graphics);
            if (drawingLine != null)
                drawingLine.Draw(graphics);
            if (Overshape != null)
                Overshape.DrawLinePoint(graphics);
        }

        public void AddCommand(ICommand cmd)//加入命令。
        {
            commands.Execute(cmd);
        }
        public void UndoCommand()//回到上一步。
        {
            commands.Undo();
        }
        public void RedoCommand()//回到原本的下一步。
        {
            commands.Redo();
        }

        public void NotifyModelChanged()
        {
            _modelChange = true;
            if (modelChanged != null)
                modelChanged();
        }

        public void SetDrawState(string shapename)
        {
            this.currentstate = this.drawstate;
            this.currentstate.ResetState();
            this._ShapeName = shapename;
            this.selectshape = null;
            NotifyModelChanged();
        }
        public void SetPointState()
        {
            this.currentstate = this.pointstate;
            this.currentstate.ResetState();
            NotifyModelChanged();
        }
        public void SetDrawLineState()
        {
            this.currentstate = this.drawLinestate;
            this.selectshape = null;
            NotifyModelChanged();
        }
    }
}
