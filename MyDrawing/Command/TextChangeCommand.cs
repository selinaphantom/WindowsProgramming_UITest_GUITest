using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MyDrawing.Command
{
    public class TextChangeCommand : ICommand
    {
        Model model;
        IShape _Shape;
        string _Text;
        string _InitText;
        public TextChangeCommand(Model model, IShape shape, string NewText, string InitText)
        {
            this.model = model;
            this._Shape = shape;
            this._Text = NewText;
            this._InitText = InitText;
        }
        public void Execute()
        {
            model.ModityText(_Shape, _Text);
            model.NotifyModelChanged();
        }
        public void UnExecute()
        {
            model.ModityText(_Shape, _InitText);
            model.NotifyModelChanged();
        }
    }
}
