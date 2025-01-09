using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Command
{
    public class TextMoveCommand : ICommand
    {
        Model model;
        IShape _Shape;
        int _NewX;
        int _NewY;
        int _InitX;
        int _InitY;
        public TextMoveCommand(Model model, IShape shape, int InitX, int InitY, int NewX, int NewY)
        {
            this.model = model;
            this._Shape = shape;
            this._NewX = NewX;
            this._NewY = NewY;
            this._InitX = InitX;
            this._InitY = InitY;
        }
        public void Execute()
        {
            _Shape._TextX = _NewX;
            _Shape._TextY = _NewY;
            model.NotifyModelChanged();
        }
        public void UnExecute()
        {
            _Shape._TextX = _InitX;
            _Shape._TextY = _InitY;
            model.NotifyModelChanged();
        }
    }
}
