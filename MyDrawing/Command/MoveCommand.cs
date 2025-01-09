using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Command
{
    public class MoveCommand : ICommand
    {
        Model model;
        IShape _Shape;
        int _InitX;
        int _InitY;
        int _NewX;
        int _NewY;
        public MoveCommand(Model model, IShape shape, int InitX, int InitY, int NewX, int NewY)
        {
            this.model = model;
            this._Shape = shape;
            this._InitX = InitX;
            this._InitY = InitY;
            this._NewX = NewX;
            this._NewY = NewY;
        }
        public void Execute()
        {
            _Shape._ShapeX = _NewX;
            _Shape._ShapeY = _NewY;
            model.NotifyModelChanged();
        }
        public void UnExecute()
        {
            _Shape._ShapeX = _InitX;
            _Shape._ShapeY = _InitY;
            model.NotifyModelChanged();
        }
    }
}
