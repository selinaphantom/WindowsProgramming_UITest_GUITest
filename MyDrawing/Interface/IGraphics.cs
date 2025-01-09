using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing
{
    public interface IGraphics//將要做畫圖，用介面來實作，實作內容在FormGraphicsAdaptor。
    {
        void ClearAll();
        void DrawLine(double x1, double y1, double x2, double y2);
        void DrawRectangle(double x1, double y1, double width, double height);
        void DrawEllipse(double x1, double y1, double width, double height);
        void FillEllipse(double x, double y, double width, double height);
        void DrawArc(double x1, double y1, double width, double height, double degreefrist, double degreeSec);
        void DrawString(string text, double x1, double y1);
        void DrawPolygon(int x, int y, int width, int height);
        void DrawEdge(string text, double x1, double y1, int X, int Y, int Width, int Height);
    }
}
