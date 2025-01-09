using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace MyDrawing.Shape
{
    public class Line
    {
        public IShape FristShape { set; get; }
        public IShape FinalShape { set; get; }
        public String FristPoint { set; get; }
        public String FinalPoint { set; get; }
        public double FristX { set; get; }
        public double FristY { set; get; }
        public double FinalX { set; get; }
        public double FinalY { set; get; }

        public Line() //解建構子。
        {

        }
        public void Draw(IGraphics graphics)
        {
            double fristX = FristShape != null ? GetPointX(FristShape, FristPoint) : FristX;
            double fristY = FristShape != null ? GetPointY(FristShape, FristPoint) : FristY;
            double finalX = FinalShape != null ? GetPointX(FinalShape, FinalPoint) : FinalX;
            double finalY = FinalShape != null ? GetPointY(FinalShape, FinalPoint) : FinalY;
            graphics.DrawLine(fristX, fristY, finalX, finalY);
        }
        public double GetPointX(IShape shape, string LinePoint)
        {
            if (LinePoint == "Top")
            {
                return shape._ShapeX + shape._ShapeWidth / 2;
            }
            else if (LinePoint == "Right")
            {
                return shape._ShapeX + shape._ShapeWidth;
            }
            else if (LinePoint == "Bottom")
            {
                return shape._ShapeX + shape._ShapeWidth / 2;
            }
            else if (LinePoint == "Left")
            {
                return shape._ShapeX;
            }
            else
            {
                return shape._ShapeX;
            }
        }
        public double GetPointY(IShape shape, string LinePoint)
        {
            if (LinePoint == "Top")
            {
                return shape._ShapeY;
            }
            else if (LinePoint == "Right")
            {
                return shape._ShapeY + shape._ShapeHeight / 2;
            }
            else if (LinePoint == "Bottom")
            {
                return shape._ShapeY + shape._ShapeHeight;
            }
            else if (LinePoint == "Left")
            {
                return shape._ShapeY + shape._ShapeHeight / 2;
            }
            else
            {
                return shape._ShapeY;
            }
        }
    }
}
