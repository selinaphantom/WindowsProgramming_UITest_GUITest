using MyDrawing.Command;
using MyDrawing.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.State
{
    public class DrawLineState : IState
    {
        Model model;
        bool _PressedState = false;
        List<String> LineConnectPoint = new List<string> { "Top", "Right", "Bottom", "Left" };

        public DrawLineState(Model model)
        {
            this.model = model;
        }
        public void ResetState()
        {
            _PressedState = false;
            this.model.drawingLine = null;
            this.model.Overshape = null;
        }
        public void MouseDown(double x, double y)
        {
            foreach (IShape shape in this.model.GetShapes())
            {
                bool flag = false;
                foreach (String ConnectPoint in LineConnectPoint)
                {
                    if (shape.IsPointInLinePoint(x, y, ConnectPoint))
                    {
                        flag = true;
                        this.model.drawingLine = new Line();
                        this.model.drawingLine.FristShape = shape;
                        this.model.drawingLine.FristPoint = ConnectPoint;
                        this.model.drawingLine.FinalX = x;
                        this.model.drawingLine.FinalY = y;
                        break;
                    }
                }
                if (flag)
                {
                    this.model.NotifyModelChanged();
                    break;
                }
            }
            _PressedState = true;
        }

        public void MouseMove(double x, double y)//滑鼠經過的圖形
        {
            this.model.Overshape = null;
            foreach (IShape shape in this.model.GetShapes())
            {
                if (shape.CheckInPoint(x, y) ||
                    shape.IsPointInLinePoint(x, y, "Top") ||
                    shape.IsPointInLinePoint(x, y, "Right") ||
                    shape.IsPointInLinePoint(x, y, "Bottom") ||
                    shape.IsPointInLinePoint(x, y, "Left"))
                {
                    this.model.Overshape = shape;
                    break;
                }
            }
            if (_PressedState && this.model.drawingLine != null)
            {
                this.model.drawingLine.FinalX = x;
                this.model.drawingLine.FinalY = y;
            }
        }
        public void MouseUp(double x, double y)
        {
            if (_PressedState && this.model.drawingLine != null)
            {
                foreach (IShape shape in this.model.GetShapes())
                {
                    bool flag = false;
                    foreach (String ConnectPoint in LineConnectPoint)
                    {
                        if (shape.IsPointInLinePoint(x, y, ConnectPoint))
                        {
                            flag = true;
                            this.model.drawingLine.FinalShape = shape;
                            this.model.drawingLine.FinalPoint = ConnectPoint;
                            bool sameShapeFlag = this.model.drawingLine.GetPointX(model.drawingLine.FristShape, this.model.drawingLine.FristPoint) == this.model.drawingLine.GetPointX(model.drawingLine.FinalShape, this.model.drawingLine.FinalPoint);
                            bool sameConnectPointFlag = this.model.drawingLine.GetPointY(model.drawingLine.FristShape, this.model.drawingLine.FristPoint) == this.model.drawingLine.GetPointY(model.drawingLine.FinalShape, this.model.drawingLine.FinalPoint);
                            if (sameShapeFlag && sameConnectPointFlag) //判斷是不是同一個圖形上的同一個點。
                                break;
                            this.model.AddCommand(new DrawLineCommand(this.model, model.drawingLine));
                            break;
                        }
                    }
                    if (flag)
                        break;
                }
                ResetState();
            }
        }
    }
}
