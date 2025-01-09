using MyDrawing.Command;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyDrawing.State
{
    internal class DrawState : IState
    {
        bool _PressedState = false;
        double _FriX = 0;
        double _FriY = 0;
        double _SecX = 0;
        double _SecY = 0;
        Factory _factory = new Factory();
        Model model;
        public DrawState(Model model)
        {
            this.model = model;
        }
        public void ResetState()
        {
            _FriX = 0;
            _FriY = 0;
            _SecX = 0;
            _SecY = 0;
        }

        public void MouseDown(double x, double y)
        {
            if (x >= 0 && y >= 0)
            {
                this.model.shape = _factory.ChoseeShape(model._ShapeName, RangeText(), _FriX.ToString(), _FriY.ToString(), _SecX.ToString(), _SecY.ToString());
                this.model.shape._ShapeX = (int)x;
                this.model.shape._ShapeY = (int)y;
                _FriX = x;
                _FriY = y;
                _PressedState = true;
            }
        }

        public void MouseMove(double x, double y)
        {
            if (_PressedState)
            {
                _SecX = x;
                _SecY = y;
                UpdataShape();
            }
        }
        public void MouseUp(double x, double y)//儲存最終的圖形。
        {
            if (_PressedState)
            {
                _SecX = x;
                _SecY = y;
                _PressedState = false;
                UpdataShape();
                model.AddCommand(new DrawCommand(this.model, this.model.shape));
                this.model.SetPointState();
            }
        }

        public void UpdataShape()//更新目前的座標。
        {
            double MinX = _FriX < _SecX ? _FriX : _SecX;
            double MaxX = _FriX < _SecX ? _SecX : _FriX;
            double MinY = _FriY < _SecY ? _FriY : _SecY;
            double MaxY = _FriY < _SecY ? _SecY : _FriY;
            this.model.shape._ShapeX = (int)MinX;
            this.model.shape._ShapeY = (int)MinY;
            this.model.shape._ShapeHeight = (int)(MaxY - MinY);
            this.model.shape._ShapeWidth = (int)(MaxX - MinX);
        }

        private string RangeText()//產生隨機文字。
        {
            Random random = new Random();
            int len = random.Next(3, 11);
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            StringBuilder RandomText = new StringBuilder(len);
            for (int i = 0; i < len; i++)
                RandomText.Append(chars[random.Next(chars.Length)]);
            return RandomText.ToString();
        }
    }
}
