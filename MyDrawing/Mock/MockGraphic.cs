using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing
{
    public class MockGraphic : IGraphics
    {
        public List<string> _task = new List<string>();
        public MockGraphic(List<string> task)
        {
            this._task = task;
        }

        public void ClearAll() //會自動清除，所以不用實作。
        {
            _task.Clear();
        }
        public void DrawLine(double x1, double y1, double x2, double y2) //畫線。
        {
            _task.Add("Line");
        }
        public void DrawRectangle(double x1, double y1, double width, double height)//畫線。
        {
            _task.Add("Rectangle");
        }
        public void DrawEllipse(double x1, double y1, double width, double height)//畫圓形、橢圓形。
        {
            _task.Add("Ellipse");
        }
        public void FillEllipse(double x, double y, double width, double height)//標出要畫線的點。
        {
            _task.Add("LineEllipse");
        }
        public void DrawArc(double x1, double y1, double width, double height, double degreefrist, double degreeSec)//畫半圓形。
        {
            _task.Add("Arc");
            if (width == 0 || height == 0)
            {
                throw new InvalidOperationException("Width or Height is zero");
            }
        }
        public void DrawString(string text, double x1, double y1)//上文字。
        {
            _task.Add("String");
        }
        public void DrawPolygon(int x, int y, int width, int height)//畫多邊形。
        {
            _task.Add("Polygon");
        }
        public void DrawEdge(string text, double x1, double y1, int X, int Y, int Width, int Height)//畫邊緣的框。
        {
            _task.Add("Edge");
        }
    }
}
