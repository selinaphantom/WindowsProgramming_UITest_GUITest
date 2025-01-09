using MyDrawing.Shape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawing.Command
{
    public class DrawLineCommand : ICommand
    {
        Model model;
        Line _Line;
        public DrawLineCommand(Model model, Line line)
        {
            this.model = model;
            this._Line = line;
        }
        public void Execute()
        {
            model.AddLine(_Line);
            model.NotifyModelChanged();
        }
        public void UnExecute()
        {
            model.DeleteLine(model.GetLines().Count - 1);
            model.NotifyModelChanged();
        }
    }
}
