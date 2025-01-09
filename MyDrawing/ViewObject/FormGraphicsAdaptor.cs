using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MyDrawing.PresentationModel
{
    class FormGraphicsAdaptor : IGraphics
    {
        Graphics _graphics;
        Pen Pen = new Pen(Color.Black, 2);
        public FormGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }
        public void ClearAll() //會自動清除，所以不用實作。
        {

        }
        public void DrawLine(double x1, double y1, double x2, double y2) //畫線。
        {
            _graphics.DrawLine(Pen, (float)x1, (float)y1, (float)x2, (float)y2);
        }
        public void DrawRectangle(double x1, double y1, double width, double height)//畫線。
        {
            _graphics.DrawRectangle(Pen, (float)x1, (float)y1, (float)width, (float)height);
        }
        public void DrawEllipse(double x1, double y1, double width, double height)//畫圓形、橢圓形。
        {
            _graphics.DrawEllipse(Pen, (float)x1, (float)y1, (float)width, (float)height);
        }
        public void FillEllipse(double x, double y, double width, double height)//標出要畫線的點。
        {
            Brush brush = Brushes.Gray;
            _graphics.FillEllipse(brush, (float)x, (float)y, (float)width, (float)height);
        }
        public void DrawArc(double x1, double y1, double width, double height, double degreefrist, double degreeSec)//畫半圓形。
        {
            _graphics.DrawArc(Pen, (float)x1, (float)y1, (float)width, (float)height, (float)degreefrist, (float)degreeSec);
        }
        public void DrawString(string text, double x1, double y1)//上文字。
        {
            _graphics.DrawString(text, new Font("Arial", 7), Brushes.Black, (float)x1, (float)y1);
        }
        public void DrawPolygon(int x, int y, int width, int height)//畫多邊形。
        {
            Point[] points = new Point[4];
            points[0] = new Point(x + width / 2, y);
            points[1] = new Point(x + width, y + height / 2);
            points[2] = new Point(x + width / 2, y + height);
            points[3] = new Point(x, y + height / 2);
            _graphics.DrawPolygon(Pen, points);
        }
        public void DrawEdge(string text, double x1, double y1, int X, int Y, int Width, int Height)//畫邊緣的框。
        {
            Pen RPen = new Pen(Color.Red, 3);
            _graphics.DrawRectangle(RPen, X, Y, Width, Height);
            Pen GPen = new Pen(Color.Gray, 2);
            int radius = 3;
            int diameter = radius * 2;

            _graphics.DrawEllipse(GPen, X - radius, Y - radius, diameter, diameter);
            _graphics.DrawEllipse(GPen, X + Width / 2 - radius, Y - radius, diameter, diameter);
            _graphics.DrawEllipse(GPen, X + Width - radius, Y - radius, diameter, diameter);
            _graphics.DrawEllipse(GPen, X + Width - radius, Y + Height / 2 - radius, diameter, diameter);
            _graphics.DrawEllipse(GPen, X + Width - radius, Y + Height - radius, diameter, diameter);
            _graphics.DrawEllipse(GPen, X + Width / 2 - radius, Y + Height - radius, diameter, diameter);
            _graphics.DrawEllipse(GPen, X - radius, Y + Height - radius, diameter, diameter);
            _graphics.DrawEllipse(GPen, X - radius, Y + Height / 2 - radius, diameter, diameter);

            float circleDiameter = 10; // 圆形直徑及文字框
            Brush circleBrush = Brushes.Orange;

            SizeF textSize = _graphics.MeasureString(text, new Font("Arial", 7));
            _graphics.DrawRectangle(RPen, (float)x1 - 5, (float)y1 - 5, textSize.Width + 10, textSize.Height + 10);

            _graphics.FillEllipse(circleBrush, (float)x1 + (float)(text.Length * 2.48), (float)y1 - 10, circleDiameter, circleDiameter);

        }
    }
}
