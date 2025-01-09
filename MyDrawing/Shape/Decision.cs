using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing
{
    public class Decision : IShape //使用IShape介面實作功能，詳細內容在IShape。
    {
        public string _ShapeName { set; get; }
        public string _ShapeText { set; get; }
        public int _ShapeX { set; get; }
        public int _ShapeY { set; get; }
        public int _ShapeWidth { set; get; }
        public int _ShapeHeight { set; get; }
        public bool _IsDraw { set; get; }
        public int _TextX { set; get; }
        public int _TextY { set; get; }
        public Decision(string InputText, int InputX, int InputY, int InputHeight, int InputWidth) //解建構子。
        {
            _ShapeName = "Decision";
            _ShapeText = InputText;
            _ShapeX = InputX;
            _ShapeY = InputY;
            _ShapeHeight = InputHeight;
            _ShapeWidth = InputWidth;
            _IsDraw = false;
        }
        public void Draw(IGraphics graphics)
        {
            graphics.DrawPolygon(_ShapeX, _ShapeY, _ShapeWidth, _ShapeHeight);
            graphics.DrawString(_ShapeText, _TextX + _ShapeX + _ShapeWidth / 2.5, _TextY + _ShapeY + _ShapeHeight / 2.5);
            _IsDraw = true;
        }
        public void DrawLinePoint(IGraphics graphics)
        {
            int radius = 6;
            int diameter = radius * 2;
            graphics.FillEllipse(_ShapeX + _ShapeWidth / 2 - radius, _ShapeY - radius, diameter, diameter);
            graphics.FillEllipse(_ShapeX + _ShapeWidth - radius, _ShapeY + _ShapeHeight / 2 - radius, diameter, diameter);
            graphics.FillEllipse(_ShapeX + _ShapeWidth / 2 - radius, _ShapeY + _ShapeHeight - radius, diameter, diameter);
            graphics.FillEllipse(_ShapeX - radius, _ShapeY + _ShapeHeight / 2 - radius, diameter, diameter);
        }
        public bool CheckInPoint(double x, double y)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddLine(_ShapeX + _ShapeWidth / 2, _ShapeY, _ShapeX + _ShapeWidth, _ShapeY + _ShapeHeight / 2);
            graphicsPath.AddLine(_ShapeX + _ShapeWidth, _ShapeY + _ShapeHeight / 2, _ShapeX + _ShapeWidth / 2, _ShapeY + _ShapeHeight);
            graphicsPath.AddLine(_ShapeX + _ShapeWidth / 2, _ShapeY + _ShapeHeight, _ShapeX, _ShapeY + _ShapeHeight / 2);
            graphicsPath.AddLine(_ShapeX, _ShapeY + _ShapeHeight / 2, _ShapeX + _ShapeWidth / 2, _ShapeY);
            graphicsPath.CloseAllFigures();
            return graphicsPath.IsVisible((float)x, (float)y);
        }
        public bool IsMouseOverCircle(int x, int y)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse((float)(_TextX + _ShapeX + _ShapeWidth / 2.5) + (float)(_ShapeText.Length * 2.48), (float)(_TextY + _ShapeY + _ShapeHeight / 2.5) - 10, 10, 10);
            return graphicsPath.IsVisible((float)x, (float)y);

        }
        public void DrawEdge(IGraphics graphics)
        {
            graphics.DrawEdge(_ShapeText, _TextX + _ShapeX + _ShapeWidth / 2.5, _TextY + _ShapeY + _ShapeHeight / 2.5, _ShapeX, _ShapeY, _ShapeWidth, _ShapeHeight);
        }
        public bool IsPointInLinePoint(double x, double y, String LinePoint)
        {
            GraphicsPath graphics = new GraphicsPath();
            int radius = 6;
            int diameter = radius * 2;
            if (LinePoint == "Top")
                graphics.AddEllipse(_ShapeX + _ShapeWidth / 2 - radius, _ShapeY - radius, diameter, diameter);
            else if (LinePoint == "Right")
                graphics.AddEllipse(_ShapeX + _ShapeWidth - radius, _ShapeY + _ShapeHeight / 2 - radius, diameter, diameter);
            else if (LinePoint == "Bottom")
                graphics.AddEllipse(_ShapeX + _ShapeWidth / 2 - radius, _ShapeY + _ShapeHeight - radius, diameter, diameter);
            else if (LinePoint == "Left")
                graphics.AddEllipse(_ShapeX - radius, _ShapeY + _ShapeHeight / 2 - radius, diameter, diameter);
            return graphics.IsVisible((float)x, (float)y);
        }
    }
}
