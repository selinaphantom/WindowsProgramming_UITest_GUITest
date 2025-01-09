using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing
{
    public interface IState
    {
        void MouseDown(double x, double y);//滑鼠按下。
        void MouseMove(double x, double y);//滑鼠移動。
        void MouseUp(double x, double y);//滑鼠放開。
        void ResetState();//重製狀態。
    }
}
