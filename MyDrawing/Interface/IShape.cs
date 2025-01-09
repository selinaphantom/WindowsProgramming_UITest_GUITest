using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing
{
    public interface IShape //將要做相同類型但可能有不同功能的類別，用介面來實作(目前使用的有:Terminator、Start、Decision、Process)。
    {
        string _ShapeName { set; get; } //類別的名稱。
        string _ShapeText { set; get; } //類別的文字。
        int _ShapeX { set; get; } //紀錄X。
        int _ShapeY { set; get; } //紀錄Y。
        int _ShapeWidth { set; get; } //紀錄Width。
        int _ShapeHeight { set; get; } //紀錄Height。
        int _TextX { set; get; }//紀錄文字X。
        int _TextY { set; get; }//紀錄文字X。
        bool _IsDraw { set; get; }//確認是否有畫到。
        void Draw(IGraphics graphics);//畫圖形。
        bool CheckInPoint(double x, double y);//確認在圖形內點擊。
        bool IsMouseOverCircle(int x, int y);//確認在文字拖移內點擊。
        void DrawEdge(IGraphics graphics);//畫框。
        void DrawLinePoint(IGraphics graphics);//畫Line出現的點。
        bool IsPointInLinePoint(double x, double y, String LinePoint);//確認圖形的四個點(上下左右)。
    }
}
