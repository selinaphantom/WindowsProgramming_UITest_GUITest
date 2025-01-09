using MyDrawing.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawing.State
{
    public class PointState : IState
    {
        Model model;
        bool _PressedState = false;
        bool _IsPressContent = false;
        bool select = false;
        IShape _LastSelectShape = null;
        double _FriX = 0;
        double _FriY = 0;
        int _InitX = 0;
        int _InitY = 0;
        int DataIndex;
        public PointState(Model model)
        {
            this.model = model;
            this.DataIndex = this.model.GetShapes().Count - 1;
        }
        public void ResetState()
        {
            DataIndex = this.model.GetShapes().Count - 1;
            _FriX = 0;
            _FriY = 0;
            _InitX = 0;
            _InitY = 0;
            _PressedState = false;
        }
        public void MouseDown(double x, double y)
        {
            this.model.selectshape = null;
            IList<IShape> shapes = this.model.GetShapes();
            select = false;
            foreach (IShape shape in Enumerable.Reverse(this.model.GetShapes()))
            {
                _IsPressContent = (this._LastSelectShape == shape) && (shape.IsMouseOverCircle((int)x, (int)y));
                if (_IsPressContent)
                {
                    this.model.selectshape = _LastSelectShape;
                    _InitX = shape._TextX;
                    _InitY = shape._TextY;
                    select = true;
                    break;
                }
                if (shape.CheckInPoint(x, y) & !select)
                {
                    this.model.selectshape = shape;
                    _InitX = shape._ShapeX;
                    _InitY = shape._ShapeY;
                    select = true;
                    break;
                }
                DataIndex = DataIndex - 1;
            }
            if (x >= 0 && y >= 0)
            {
                _LastSelectShape = model.selectshape;
                _PressedState = true;
                _FriX = x;
                _FriY = y;
            }
        }
        public void MouseMove(double x, double y)
        {
            if (_PressedState)
            {
                if (this.model.selectshape != null) //確保不會出現null的狀況
                {
                    double X = x - _FriX;
                    double Y = y - _FriY;
                    if (_IsPressContent)
                    {
                        this.model.selectshape._TextX += (int)X;
                        this.model.selectshape._TextY += (int)Y;
                    }
                    else
                    {
                        this.model.selectshape._ShapeX += (int)X;
                        this.model.selectshape._ShapeY += (int)Y;

                    }
                    _FriX = x;
                    _FriY = y;
                }
            }
        }
        public void MouseUp(double x, double y)
        {

            if (_PressedState)
            {
                if (this.model.selectshape != null) //確保不會出現null的狀況
                {
                    if (_IsPressContent)
                    {
                        this.model.selectshape._TextX += (int)(x - _FriX);
                        this.model.selectshape._TextY += (int)(y - _FriY);
                        if (_InitX != this.model.selectshape._TextX || _InitY != this.model.selectshape._TextY)//如果移動的位址一樣則不新增指令(解決Command過多)。
                            this.model.AddCommand(new TextMoveCommand(this.model, this.model.selectshape, _InitX, _InitY, this.model.selectshape._TextX, this.model.selectshape._TextY));
                    }
                    else
                    {
                        this.model.selectshape._ShapeX += (int)(x - _FriX);
                        this.model.selectshape._ShapeY += (int)(y - _FriY);
                        if (_InitX != this.model.selectshape._ShapeX || _InitY != this.model.selectshape._ShapeY)//如果移動的位址一樣則不新增指令(解決Command過多)。
                            this.model.AddCommand(new MoveCommand(this.model, this.model.selectshape, _InitX, _InitY, this.model.selectshape._ShapeX, this.model.selectshape._ShapeY));
                    }
                }
            }
            _PressedState = false;
        }
    }
}
